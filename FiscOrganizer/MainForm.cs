using FiscOrganizer.Core.Contracts;
using FiscOrganizer.Core.CustomEventArgs;
using FiscOrganizer.Core.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FiscOrganizer;

/// <summary>
/// Main form for the FiscOrganizer application. Handles UI logic and binds to the OrganizeModel.
/// </summary>
public partial class MainForm : Form, INotifyPropertyChanged
{
    /// <summary>
    /// The model containing organization settings and file items.
    /// </summary>
    public OrganizeModel _organizeModel = new();
    /// <summary>
    /// Service responsible for organizing files.
    /// </summary>
    private readonly IOrganizeService _organizeService;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    /// <param name="organizeService">The service used to organize files.</param>
    public MainForm(IOrganizeService organizeService)
    {
        InitializeComponent();
        SelectAllButton.Click += async (_, _) => await SelectAllButton_ClickAsync();
        ToggleSelectionButton.Click += async (_, _) => await ToggleSelectionButton_ClickAsync();
        OrganizeFilesButton.Click += async (_, _) => await OrganizeFilesButton_ClickAsync();


        _organizeService = organizeService;
    }

    /// <summary>
    /// Gets or sets the organization model bound to the form.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public OrganizeModel OrganizeModel
    {
        get
        {
            return _organizeModel;
        }
        set
        {
            _organizeModel = value;
            OnPropertyChanged();
        }
    }

    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises the PropertyChanged event.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Handles the form load event. Sets up UI context and binds controls.
    /// </summary>
    private void MainForm_Load(object sender, EventArgs e)
    {
        FileItem.UiContext = SynchronizationContext.Current;

        SetForeColorRecursive(this, Color.Gainsboro);
        BindControls();
        fileItemBindingSource.DataSource = OrganizeModel.FileItems;
    }

    /// <summary>
    /// Recursively sets the ForeColor of all controls.
    /// </summary>
    /// <param name="parent">The parent control.</param>
    /// <param name="foreColor">The color to set.</param>
    private static void SetForeColorRecursive(Control parent, Color foreColor)
    {
        parent.ForeColor = foreColor;
        foreach (Control child in parent.Controls)
        {
            SetForeColorRecursive(child, foreColor);
        }
    }

    /// <summary>
    /// Binds UI controls to the properties of the OrganizeModel.
    /// </summary>
    private void BindControls()
    {
        DestinyFolderTextBox.DataBindings.Clear();
        DestinyFolderTextBox.DataBindings.Add("Text", OrganizeModel, nameof(OrganizeModel.DestinyFolder), false, DataSourceUpdateMode.OnPropertyChanged);
        ChangeFileNameCheckBox.DataBindings.Clear();
        ChangeFileNameCheckBox.DataBindings.Add("Checked", OrganizeModel, nameof(OrganizeModel.ChangeFileName), false, DataSourceUpdateMode.OnPropertyChanged);
        MoveNotIdentifiedCheckBox.DataBindings.Clear();
        MoveNotIdentifiedCheckBox.DataBindings.Add("Checked", OrganizeModel, nameof(OrganizeModel.MoveNotIdentified), false, DataSourceUpdateMode.OnPropertyChanged);
        SeparateOriginalsCheckBox.DataBindings.Clear();
        SeparateOriginalsCheckBox.DataBindings.Add("Checked", OrganizeModel, nameof(OrganizeModel.SeparateOriginals), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    /// <summary>
    /// Handles log events from the organize service and appends messages to the log textbox.
    /// </summary>
    private void OrganizeService_LogEvent(object sender, LogEventArgs e)
    {
        LogsTextBox.BeginInvoke(new Action(() =>
        {
            LogsTextBox.AppendText(e.Message);
            LogsTextBox.ScrollToCaret();
        }));
    }

    /// <summary>
    /// Handles the SelectFiles button click event. Allows user to select files to organize.
    /// </summary>
    private void SelectFilesButton_Click(object sender, EventArgs e)
    {
        using OpenFileDialog dialog = new()
        {
            Filter = "Arquivos Texto|*.txt",
            Multiselect = true,
            Title = "Selecione os arquivos SPED que serão movidos para a pasta de destino:"
        };

        var result = dialog.ShowDialog();

        if (result != DialogResult.OK)
        {
            return;
        }

        foreach (var fileName in dialog.FileNames)
        {
            FileItem newFile = new() { FullPath = fileName, Selected = true };
            if (!OrganizeModel.FileItems.Contains(newFile))
            {
                OrganizeModel.FileItems.Add(newFile);
            }
        }
    }

    /// <summary>
    /// Handles the SelectFolder button click event. Allows user to select a folder containing files to organize.
    /// </summary>
    private void SelectFolderButton_Click(object sender, EventArgs e)
    {
        using FolderBrowserDialog dialog = new()
        {
            Description = "Selecione a pasta que contêm os arquivos SPED que serão movidos para a pasta de destino",
            ShowNewFolderButton = false,
            Multiselect = true,
            UseDescriptionForTitle = true
        };

        var result = dialog.ShowDialog();
        if (result != DialogResult.OK)
        {
            return;
        }

        Cursor = Cursors.WaitCursor;
        try
        {
            var files = Directory.GetFiles(dialog.SelectedPath, "*.txt", SearchOption.AllDirectories);
            foreach (var fileName in files)
            {
                FileItem newFile = new() { FullPath = fileName, Selected = true };
                if (!OrganizeModel.FileItems.Contains(newFile))
                {
                    OrganizeModel.FileItems.Add(newFile);
                }
            }
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    /// <summary>
    /// Removes all selected files from the organization model.
    /// </summary>
    private void RemoveSelectedButton_Click(object sender, EventArgs e)
    {
        var toRemove = OrganizeModel.FileItems.Where(f => f.Selected);
        foreach (var item in toRemove.ToList())
        {
            OrganizeModel.FileItems.Remove(item);
        }
    }

    /// <summary>
    /// Selects or deselects all files in the organization model.
    /// </summary>
    private async Task SelectAllButton_ClickAsync()
    {
        Cursor = Cursors.WaitCursor;
        bool selectAll = SelectAllButton.IconChar == FontAwesome.Sharp.IconChar.Check;
        try
        {
            await Task.Run(() =>
            {
                lock (OrganizeModel.FileItems)
                {
                    foreach (var item in OrganizeModel.FileItems)
                    {
                        item.Selected = selectAll;
                    }
                }
            });
            if (selectAll)
            {
                SelectAllButton.IconChar = FontAwesome.Sharp.IconChar.Cancel;
                SelectAllButton.Text = "Desmarcar Todos";
            }
            else
            {
                SelectAllButton.IconChar = FontAwesome.Sharp.IconChar.Check;
                SelectAllButton.Text = "Marcar Todos";
            }
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    /// <summary>
    /// Toggles the selection state of all files in the organization model.
    /// </summary>
    private async Task ToggleSelectionButton_ClickAsync()
    {
        Cursor = Cursors.WaitCursor;
        try
        {
            await Task.Run(() =>
            {
                lock (OrganizeModel.FileItems)
                {
                    foreach (var item in OrganizeModel.FileItems)
                    {
                        item.Selected = !item.Selected;
                    }
                }
            });
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    /// <summary>
    /// Handles the DestinyFolder button click event. Allows user to select the destination folder for organized files.
    /// </summary>
    private void DestinyFolderButton_Click(object sender, EventArgs e)
    {
        using FolderBrowserDialog dialog = new()
        {
            Description = "Selecione a pasta de DESTINO dos arquivos SPED",
            ShowNewFolderButton = true,
            Multiselect = false,
            UseDescriptionForTitle = true
        };

        var result = dialog.ShowDialog();
        if (result != DialogResult.OK)
        {
            return;
        }
        OrganizeModel.DestinyFolder = dialog.SelectedPath;
    }

    /// <summary>
    /// Initiates the organization process for selected files using the organize service.
    /// </summary>
    private async Task OrganizeFilesButton_ClickAsync()
    {
        var sb = new StringBuilder();
        if (string.IsNullOrEmpty(OrganizeModel.DestinyFolder))
        {
            sb.AppendLine("Selecione a pasta de destino dos arquivos!");
        }
        if (OrganizeModel.FileItems.Count == 0)
        {
            sb.AppendLine("Nenhum arquivo selecionado!");
        }

        if (sb.Length > 0)
        {
            sb.AppendLine("");
            sb.AppendLine("Processo abortado!");
            MessageBox.Show(sb.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            _organizeService!.LogEvent += OrganizeService_LogEvent!;
            await _organizeService.ProcessAsync(OrganizeModel, new());
            _organizeService!.LogEvent -= OrganizeService_LogEvent!;
            MessageBox.Show("Processo de organização dos arquivos finalizado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LogsTextBox.AppendText(Environment.NewLine + "Processo de organização dos arquivos finalizado!" + Environment.NewLine);

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao iniciar o processo de organização dos arquivos. {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Clears the form, resets the organization model, and UI controls.
    /// </summary>
    private void ClearFormButton_Click(object sender, EventArgs e)
    {
        OrganizeModel = new();

        fileItemBindingSource.DataSource = OrganizeModel.FileItems;

        LogsTextBox.Clear();

        BindControls();

        Refresh();
    }
}
