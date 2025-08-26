using FiscOrganizer.Models;
using System.Diagnostics.CodeAnalysis;

namespace FiscOrganizer.Comparers;

public sealed class ProcessedFileModelCnpjBaseComparer : IEqualityComparer<ProcessedFileModel>
{
    public bool Equals(ProcessedFileModel? x, ProcessedFileModel? y)
    {
        if (x == null && y == null) return true;
        if (x == null || y == null) return false;
        return x.CnpjBase == y.CnpjBase;
    }

    public int GetHashCode([DisallowNull] ProcessedFileModel obj)
    {
        return obj.CnpjBase != null ? obj.CnpjBase.GetHashCode() : 0;
    }
}
