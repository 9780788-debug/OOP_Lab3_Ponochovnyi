using System.Globalization;
using System.Reflection;
using System.Text;

namespace Lab33.DAL.Providers;

// Спільні рефлексивні допоміжні методи для бінарного та користувацького провайдерів.
internal static class PropertyMap<T>
{
    // Усі публічні властивості з get і set (порядок однаковий при записі та читанні).
    public static readonly PropertyInfo[] Properties = typeof(T)
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(p => p.CanRead && p.CanWrite)
        .ToArray();

    // Значення -> текст (числа в інваріантній культурі).
    public static string ToText(object? value) => value switch
    {
        null => "",
        string s => Escape(s),
        IFormattable f => f.ToString(null, CultureInfo.InvariantCulture),
        _ => Escape(value.ToString() ?? "")
    };

    // Текст -> значення потрібного типу.
    public static object FromText(Type type, string text) =>
        type == typeof(string)
            ? Unescape(text)
            : Convert.ChangeType(text, type, CultureInfo.InvariantCulture);

    // Екранування, щоб значення не ламало рядковий формат.
    private static string Escape(string s) =>
        s.Replace("\\", "\\\\").Replace("\n", "\\n").Replace("\r", "\\r");

    // Зворотна операція до Escape.
    private static string Unescape(string s)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '\\' && i + 1 < s.Length)
            {
                i++;
                sb.Append(s[i] switch { 'n' => '\n', 'r' => '\r', _ => s[i] });
            }
            else sb.Append(s[i]);
        }
        return sb.ToString();
    }
}
