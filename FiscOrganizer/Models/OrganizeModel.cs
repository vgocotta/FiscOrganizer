using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FiscOrganizer.Models;

public class OrganizeModel : INotifyPropertyChanged
{
    private string? _destinyFolder;
    private bool _changeFileName;
    private bool _moveNotIdentified;
    private bool _separateOriginals;

    public OrganizeModel()
    {
    }

    public string? DestinyFolder
    {
        get => _destinyFolder;
        set
        {
            _destinyFolder = value;
            OnPropertyChanged();
        }
    }

    public bool ChangeFileName
    {
        get => _changeFileName;
        set
        {
            _changeFileName = value;
            OnPropertyChanged();
        }
    }

    public bool MoveNotIdentified
    {
        get => _moveNotIdentified;
        set
        {
            _moveNotIdentified = value;
            OnPropertyChanged();
        }
    }

    public bool SeparateOriginals
    {
        get => _separateOriginals;
        set
        {
            _separateOriginals = value;
            OnPropertyChanged();
        }
    }

    public BindingList<FileItem> FileItems { get; set; } = [];

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
