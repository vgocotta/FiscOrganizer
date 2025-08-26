namespace FiscOrganizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            FilesGroupBox = new GroupBox();
            SelectedFilesDataGridView = new DataGridView();
            selectedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            fullPathDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fileItemBindingSource = new BindingSource(components);
            SelectFilesPanel = new Panel();
            ToggleSelectionButton = new FontAwesome.Sharp.IconButton();
            SelectAllButton = new FontAwesome.Sharp.IconButton();
            RemoveSelectedButton = new FontAwesome.Sharp.IconButton();
            SelectFolderButton = new FontAwesome.Sharp.IconButton();
            SelectFilesButton = new FontAwesome.Sharp.IconButton();
            DestinyFolderGroupBox = new GroupBox();
            DestinyFolderTextBox = new TextBox();
            DestinyFolderButton = new FontAwesome.Sharp.IconButton();
            OptionsGroupBox = new GroupBox();
            SeparateOriginalsCheckBox = new CheckBox();
            MoveNotIdentifiedCheckBox = new CheckBox();
            ChangeFileNameCheckBox = new CheckBox();
            OrganizeFilesButton = new FontAwesome.Sharp.IconButton();
            ClearFormButton = new FontAwesome.Sharp.IconButton();
            LogGroupBox = new GroupBox();
            LogsTextBox = new TextBox();
            FilesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedFilesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource).BeginInit();
            SelectFilesPanel.SuspendLayout();
            DestinyFolderGroupBox.SuspendLayout();
            OptionsGroupBox.SuspendLayout();
            LogGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // FilesGroupBox
            // 
            FilesGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FilesGroupBox.Controls.Add(SelectedFilesDataGridView);
            FilesGroupBox.Controls.Add(SelectFilesPanel);
            FilesGroupBox.ForeColor = Color.Gainsboro;
            FilesGroupBox.Location = new Point(11, 10);
            FilesGroupBox.Name = "FilesGroupBox";
            FilesGroupBox.Size = new Size(988, 377);
            FilesGroupBox.TabIndex = 0;
            FilesGroupBox.TabStop = false;
            FilesGroupBox.Text = "Arquivos";
            // 
            // SelectedFilesDataGridView
            // 
            SelectedFilesDataGridView.AllowUserToAddRows = false;
            SelectedFilesDataGridView.AllowUserToDeleteRows = false;
            SelectedFilesDataGridView.AllowUserToOrderColumns = true;
            SelectedFilesDataGridView.AllowUserToResizeColumns = false;
            SelectedFilesDataGridView.AllowUserToResizeRows = false;
            SelectedFilesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SelectedFilesDataGridView.AutoGenerateColumns = false;
            SelectedFilesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectedFilesDataGridView.Columns.AddRange(new DataGridViewColumn[] { selectedDataGridViewCheckBoxColumn, fullPathDataGridViewTextBoxColumn });
            SelectedFilesDataGridView.DataSource = fileItemBindingSource;
            SelectedFilesDataGridView.Location = new Point(5, 21);
            SelectedFilesDataGridView.Name = "SelectedFilesDataGridView";
            SelectedFilesDataGridView.Size = new Size(977, 309);
            SelectedFilesDataGridView.TabIndex = 1;
            // 
            // selectedDataGridViewCheckBoxColumn
            // 
            selectedDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            selectedDataGridViewCheckBoxColumn.DataPropertyName = "Selected";
            selectedDataGridViewCheckBoxColumn.HeaderText = "Seleção";
            selectedDataGridViewCheckBoxColumn.Name = "selectedDataGridViewCheckBoxColumn";
            selectedDataGridViewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            selectedDataGridViewCheckBoxColumn.Width = 84;
            // 
            // fullPathDataGridViewTextBoxColumn
            // 
            fullPathDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fullPathDataGridViewTextBoxColumn.DataPropertyName = "FullPath";
            dataGridViewCellStyle1.ForeColor = Color.Black;
            fullPathDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            fullPathDataGridViewTextBoxColumn.HeaderText = "Caminho Arquivo";
            fullPathDataGridViewTextBoxColumn.MaxInputLength = 256;
            fullPathDataGridViewTextBoxColumn.Name = "fullPathDataGridViewTextBoxColumn";
            fullPathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileItemBindingSource
            // 
            fileItemBindingSource.DataSource = typeof(Models.FileItem);
            // 
            // SelectFilesPanel
            // 
            SelectFilesPanel.Controls.Add(ToggleSelectionButton);
            SelectFilesPanel.Controls.Add(SelectAllButton);
            SelectFilesPanel.Controls.Add(RemoveSelectedButton);
            SelectFilesPanel.Controls.Add(SelectFolderButton);
            SelectFilesPanel.Controls.Add(SelectFilesButton);
            SelectFilesPanel.Dock = DockStyle.Bottom;
            SelectFilesPanel.Location = new Point(3, 335);
            SelectFilesPanel.Name = "SelectFilesPanel";
            SelectFilesPanel.Size = new Size(982, 39);
            SelectFilesPanel.TabIndex = 0;
            // 
            // ToggleSelectionButton
            // 
            ToggleSelectionButton.FlatStyle = FlatStyle.Flat;
            ToggleSelectionButton.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            ToggleSelectionButton.IconColor = Color.Gainsboro;
            ToggleSelectionButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ToggleSelectionButton.IconSize = 24;
            ToggleSelectionButton.Location = new Point(592, 3);
            ToggleSelectionButton.Name = "ToggleSelectionButton";
            ToggleSelectionButton.Size = new Size(191, 34);
            ToggleSelectionButton.TabIndex = 4;
            ToggleSelectionButton.Text = "Inverter Seleção";
            ToggleSelectionButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ToggleSelectionButton.UseVisualStyleBackColor = true;
            // 
            // SelectAllButton
            // 
            SelectAllButton.FlatStyle = FlatStyle.Flat;
            SelectAllButton.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            SelectAllButton.IconColor = Color.Gainsboro;
            SelectAllButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SelectAllButton.IconSize = 24;
            SelectAllButton.Location = new Point(396, 3);
            SelectAllButton.Name = "SelectAllButton";
            SelectAllButton.Size = new Size(191, 34);
            SelectAllButton.TabIndex = 3;
            SelectAllButton.Text = "Desmarcar Todos";
            SelectAllButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            SelectAllButton.UseVisualStyleBackColor = true;
            // 
            // RemoveSelectedButton
            // 
            RemoveSelectedButton.FlatStyle = FlatStyle.Flat;
            RemoveSelectedButton.IconChar = FontAwesome.Sharp.IconChar.FileCircleMinus;
            RemoveSelectedButton.IconColor = Color.Gainsboro;
            RemoveSelectedButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RemoveSelectedButton.IconSize = 24;
            RemoveSelectedButton.Location = new Point(788, 3);
            RemoveSelectedButton.Name = "RemoveSelectedButton";
            RemoveSelectedButton.Size = new Size(191, 34);
            RemoveSelectedButton.TabIndex = 2;
            RemoveSelectedButton.Text = "Remover Selecionados";
            RemoveSelectedButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            RemoveSelectedButton.UseVisualStyleBackColor = true;
            RemoveSelectedButton.Click += RemoveSelectedButton_Click;
            // 
            // SelectFolderButton
            // 
            SelectFolderButton.FlatStyle = FlatStyle.Flat;
            SelectFolderButton.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            SelectFolderButton.IconColor = Color.Gainsboro;
            SelectFolderButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SelectFolderButton.IconSize = 24;
            SelectFolderButton.Location = new Point(199, 3);
            SelectFolderButton.Name = "SelectFolderButton";
            SelectFolderButton.Size = new Size(191, 34);
            SelectFolderButton.TabIndex = 1;
            SelectFolderButton.Text = "Selecionar Pasta";
            SelectFolderButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            SelectFolderButton.UseVisualStyleBackColor = true;
            SelectFolderButton.Click += SelectFolderButton_Click;
            // 
            // SelectFilesButton
            // 
            SelectFilesButton.FlatStyle = FlatStyle.Flat;
            SelectFilesButton.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            SelectFilesButton.IconColor = Color.Gainsboro;
            SelectFilesButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SelectFilesButton.IconSize = 24;
            SelectFilesButton.Location = new Point(3, 3);
            SelectFilesButton.Name = "SelectFilesButton";
            SelectFilesButton.Size = new Size(191, 34);
            SelectFilesButton.TabIndex = 0;
            SelectFilesButton.Text = "Selecionar Arquivos";
            SelectFilesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            SelectFilesButton.UseVisualStyleBackColor = true;
            SelectFilesButton.Click += SelectFilesButton_Click;
            // 
            // DestinyFolderGroupBox
            // 
            DestinyFolderGroupBox.Controls.Add(DestinyFolderTextBox);
            DestinyFolderGroupBox.Controls.Add(DestinyFolderButton);
            DestinyFolderGroupBox.ForeColor = Color.Gainsboro;
            DestinyFolderGroupBox.Location = new Point(11, 392);
            DestinyFolderGroupBox.Name = "DestinyFolderGroupBox";
            DestinyFolderGroupBox.Size = new Size(988, 60);
            DestinyFolderGroupBox.TabIndex = 1;
            DestinyFolderGroupBox.TabStop = false;
            DestinyFolderGroupBox.Text = "Pasta de destino dos arquivos";
            // 
            // DestinyFolderTextBox
            // 
            DestinyFolderTextBox.Location = new Point(46, 27);
            DestinyFolderTextBox.Name = "DestinyFolderTextBox";
            DestinyFolderTextBox.ReadOnly = true;
            DestinyFolderTextBox.Size = new Size(936, 23);
            DestinyFolderTextBox.TabIndex = 3;
            // 
            // DestinyFolderButton
            // 
            DestinyFolderButton.FlatStyle = FlatStyle.Flat;
            DestinyFolderButton.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            DestinyFolderButton.IconColor = Color.Gainsboro;
            DestinyFolderButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            DestinyFolderButton.IconSize = 24;
            DestinyFolderButton.Location = new Point(5, 21);
            DestinyFolderButton.Name = "DestinyFolderButton";
            DestinyFolderButton.Size = new Size(36, 34);
            DestinyFolderButton.TabIndex = 2;
            DestinyFolderButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            DestinyFolderButton.UseVisualStyleBackColor = true;
            DestinyFolderButton.Click += DestinyFolderButton_Click;
            // 
            // OptionsGroupBox
            // 
            OptionsGroupBox.Controls.Add(SeparateOriginalsCheckBox);
            OptionsGroupBox.Controls.Add(MoveNotIdentifiedCheckBox);
            OptionsGroupBox.Controls.Add(ChangeFileNameCheckBox);
            OptionsGroupBox.ForeColor = Color.Gainsboro;
            OptionsGroupBox.Location = new Point(11, 457);
            OptionsGroupBox.Name = "OptionsGroupBox";
            OptionsGroupBox.Size = new Size(988, 52);
            OptionsGroupBox.TabIndex = 2;
            OptionsGroupBox.TabStop = false;
            OptionsGroupBox.Text = "Opções";
            // 
            // SeparateOriginalsCheckBox
            // 
            SeparateOriginalsCheckBox.AutoSize = true;
            SeparateOriginalsCheckBox.Location = new Point(775, 21);
            SeparateOriginalsCheckBox.Name = "SeparateOriginalsCheckBox";
            SeparateOriginalsCheckBox.Size = new Size(206, 21);
            SeparateOriginalsCheckBox.TabIndex = 2;
            SeparateOriginalsCheckBox.Text = "Separar arquivos retificados";
            SeparateOriginalsCheckBox.UseVisualStyleBackColor = true;
            // 
            // MoveNotIdentifiedCheckBox
            // 
            MoveNotIdentifiedCheckBox.AutoSize = true;
            MoveNotIdentifiedCheckBox.Location = new Point(342, 21);
            MoveNotIdentifiedCheckBox.Name = "MoveNotIdentifiedCheckBox";
            MoveNotIdentifiedCheckBox.Size = new Size(345, 21);
            MoveNotIdentifiedCheckBox.TabIndex = 1;
            MoveNotIdentifiedCheckBox.Text = "Mover arquivos .txt não identificados como SPED";
            MoveNotIdentifiedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChangeFileNameCheckBox
            // 
            ChangeFileNameCheckBox.AutoSize = true;
            ChangeFileNameCheckBox.Location = new Point(5, 21);
            ChangeFileNameCheckBox.Name = "ChangeFileNameCheckBox";
            ChangeFileNameCheckBox.Size = new Size(272, 21);
            ChangeFileNameCheckBox.TabIndex = 0;
            ChangeFileNameCheckBox.Text = "Alterar o nome do arquivo no destino";
            ChangeFileNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // OrganizeFilesButton
            // 
            OrganizeFilesButton.FlatStyle = FlatStyle.Flat;
            OrganizeFilesButton.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            OrganizeFilesButton.IconColor = Color.Gainsboro;
            OrganizeFilesButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            OrganizeFilesButton.IconSize = 24;
            OrganizeFilesButton.Location = new Point(11, 514);
            OrganizeFilesButton.Name = "OrganizeFilesButton";
            OrganizeFilesButton.Size = new Size(191, 34);
            OrganizeFilesButton.TabIndex = 3;
            OrganizeFilesButton.Text = "Mover Arquivos";
            OrganizeFilesButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            OrganizeFilesButton.UseVisualStyleBackColor = true;
            // 
            // ClearFormButton
            // 
            ClearFormButton.FlatStyle = FlatStyle.Flat;
            ClearFormButton.IconChar = FontAwesome.Sharp.IconChar.Broom;
            ClearFormButton.IconColor = Color.Gainsboro;
            ClearFormButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ClearFormButton.IconSize = 24;
            ClearFormButton.Location = new Point(807, 514);
            ClearFormButton.Name = "ClearFormButton";
            ClearFormButton.Size = new Size(191, 34);
            ClearFormButton.TabIndex = 4;
            ClearFormButton.Text = "Limpar Formuário";
            ClearFormButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            ClearFormButton.UseVisualStyleBackColor = true;
            ClearFormButton.Click += ClearFormButton_Click;
            // 
            // LogGroupBox
            // 
            LogGroupBox.Controls.Add(LogsTextBox);
            LogGroupBox.ForeColor = Color.Gainsboro;
            LogGroupBox.Location = new Point(12, 554);
            LogGroupBox.Name = "LogGroupBox";
            LogGroupBox.Size = new Size(985, 191);
            LogGroupBox.TabIndex = 5;
            LogGroupBox.TabStop = false;
            LogGroupBox.Text = "Logs";
            // 
            // LogsTextBox
            // 
            LogsTextBox.Dock = DockStyle.Fill;
            LogsTextBox.Location = new Point(3, 19);
            LogsTextBox.Multiline = true;
            LogsTextBox.Name = "LogsTextBox";
            LogsTextBox.ReadOnly = true;
            LogsTextBox.ScrollBars = ScrollBars.Both;
            LogsTextBox.Size = new Size(979, 169);
            LogsTextBox.TabIndex = 0;
            LogsTextBox.WordWrap = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1009, 757);
            Controls.Add(LogGroupBox);
            Controls.Add(ClearFormButton);
            Controls.Add(OrganizeFilesButton);
            Controls.Add(OptionsGroupBox);
            Controls.Add(DestinyFolderGroupBox);
            Controls.Add(FilesGroupBox);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Gainsboro;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fisc Organizer";
            Load += MainForm_Load;
            FilesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SelectedFilesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource).EndInit();
            SelectFilesPanel.ResumeLayout(false);
            DestinyFolderGroupBox.ResumeLayout(false);
            DestinyFolderGroupBox.PerformLayout();
            OptionsGroupBox.ResumeLayout(false);
            OptionsGroupBox.PerformLayout();
            LogGroupBox.ResumeLayout(false);
            LogGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox FilesGroupBox;
        private Panel SelectFilesPanel;
        private FontAwesome.Sharp.IconButton SelectFolderButton;
        private FontAwesome.Sharp.IconButton SelectFilesButton;
        private DataGridView SelectedFilesDataGridView;
        private BindingSource fileItemBindingSource;
        private DataGridViewCheckBoxColumn selectedDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn fullPathDataGridViewTextBoxColumn;
        private FontAwesome.Sharp.IconButton RemoveSelectedButton;
        private FontAwesome.Sharp.IconButton ToggleSelectionButton;
        private FontAwesome.Sharp.IconButton SelectAllButton;
        private GroupBox DestinyFolderGroupBox;
        private TextBox DestinyFolderTextBox;
        private FontAwesome.Sharp.IconButton DestinyFolderButton;
        private GroupBox OptionsGroupBox;
        private CheckBox ChangeFileNameCheckBox;
        private CheckBox MoveNotIdentifiedCheckBox;
        private CheckBox SeparateOriginalsCheckBox;
        private FontAwesome.Sharp.IconButton OrganizeFilesButton;
        private FontAwesome.Sharp.IconButton ClearFormButton;
        private GroupBox LogGroupBox;
        private TextBox LogsTextBox;
    }
}
