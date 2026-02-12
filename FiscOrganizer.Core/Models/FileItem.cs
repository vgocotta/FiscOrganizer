using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FiscOrganizer.Core.Models;

public class FileItem : INotifyPropertyChanged
{
    public static SynchronizationContext? UiContext { get; set; }

    private bool _selected;

    public bool Selected
    {
        get => _selected;
        set
        {
            if (_selected != value)
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }
    }

    public string FullPath { get; set; } = null!;

    public event PropertyChangedEventHandler? PropertyChanged;

    public override bool Equals(object? obj)
    {
        return obj is FileItem item &&
               FullPath == item.FullPath;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FullPath);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        if (UiContext != null)
        {
            UiContext.Post(_ => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)), null);
        }
        else
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
