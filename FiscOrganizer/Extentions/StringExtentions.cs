using FiscOrganizer.Utils;
using System.Globalization;
using System.Text;

namespace FiscOrganizer.Extentions;

public static class StringExtentions
{
    public static int GetFieldCount(this string value, char separator)
    {
        int count = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char c = value[i];
            if (c == separator)
            {
                count++;
            }
        }
        return count;
    }

    public static string GetSpedField(this string spedLine, int index)
    {
        char separator = '|';
        int freq = spedLine.Count(f => f == separator);
        if (freq <= index)
        {
            return "";
        }
        StringBuilder sb = new();
        int count = 0;
        for (int i = 0; i < spedLine.Length; i++)
        {
            if (count > index) { break; }
            char c = spedLine[i];
            if (c == separator)
            {
                count++;
                continue;
            }
            if (count == index)
            {
                sb.Append(c);
            }
        }
        return sb.ToString().Trim().ToUpper();
    }

    public static int GetSpedFieldInt(this string spedLine, int index)
    {
        string field = GetSpedField(spedLine, index);
        if (string.IsNullOrEmpty(field) || !int.TryParse(field, out int result))
        {
            return -1;
        }
        return result;
    }
    public static DateTime GetSpedFieldDateTime(this string spedLine, int index)
    {
        string field = GetSpedField(spedLine, index);
        if (!DateTime.TryParseExact(field, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataConvertida)) throw new ArgumentException($"A data estava num formato inválido: {field}");
        return dataConvertida;
    }

    public static int GetIndexFirstCnpj(this string spedLine)
    {
        int count = spedLine.GetFieldCount('|');

        for (int i = 0; i < count; i++)
        {
            string field = spedLine.GetSpedField(i);
            if (!string.IsNullOrEmpty(field) && ValidadorCnpj.IsCnpj(field))
            {
                return i;
            }
        }
        return -1;
    }
}
