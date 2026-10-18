using System.Globalization;
using Lab33.BLL.Exceptions;

namespace Lab33.PL;

// Допоміжні методи введення. Помилки не ловимо тут - вони піднімаються до меню.
public static class ConsoleInput
{
    // Читає рядок з підказкою.
    public static string ReadString(string prompt)
    {
        Console.Write($"{prompt}: ");
        return Console.ReadLine()?.Trim() ?? "";
    }

    // Читає ціле число.
    public static int ReadInt(string prompt)
    {
        string text = ReadString(prompt);
        if (!int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
            throw new InvalidEntityDataException($"'{text}' не є цілим числом.");
        return value;
    }

    // Читає дійсне число (кома або крапка).
    public static double ReadDouble(string prompt)
    {
        string text = ReadString(prompt).Replace(',', '.');
        if (!double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            throw new InvalidEntityDataException($"'{text}' не є числом.");
        return value;
    }
}
