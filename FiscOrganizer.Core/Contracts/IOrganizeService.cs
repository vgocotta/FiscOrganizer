using FiscOrganizer.Core.CustomEventArgs;
using FiscOrganizer.Core.Models;

namespace FiscOrganizer.Core.Contracts;

public interface IOrganizeService
{
    List<string> Logs { get; set; }

    event EventHandler<LogEventArgs>? LogEvent;
    event EventHandler<EventArgs>? ProcessFile;

    void Cancel(bool revert = false);
    Task ProcessAsync(OrganizeModel organize, CancellationTokenSource cancellationTokenSource);
}