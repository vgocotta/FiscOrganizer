namespace FiscOrganizer.Core.CustomEventArgs;

public class LogEventArgs : EventArgs
{
    private readonly string message;

    public LogEventArgs(string message)
    {
        this.message = message + Environment.NewLine;
    }

    public string Message => message;
}
