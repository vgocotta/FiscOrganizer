using System.ComponentModel;
using System.Reflection;

namespace FiscOrganizer.Extentions;

public static class EnumExtentions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());

        if (fieldInfo == null)
        {
            return value.ToString();
        }

        return fieldInfo.GetCustomAttribute<DescriptionAttribute>(false) is DescriptionAttribute attribute ? attribute.Description : value.ToString();

    }
}
