using Lab33.BLL.Exceptions;

namespace Lab33.BLL.Validation;

// Прості перевірки значень для властивостей моделей.
public static class Guard
{
    // Рядок не порожній; повертає обрізаний рядок.
    public static string NotEmpty(string? value, string field)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEntityDataException($"{field} не може бути порожнім.");
        return value.Trim();
    }

    // Ціле число в діапазоні.
    public static int InRange(int value, int min, int max, string field)
    {
        if (value < min || value > max)
            throw new InvalidEntityDataException($"{field} має бути від {min} до {max}.");
        return value;
    }

    // Дійсне число в діапазоні.
    public static double InRange(double value, double min, double max, string field)
    {
        if (double.IsNaN(value) || value < min || value > max)
            throw new InvalidEntityDataException($"{field} має бути від {min} до {max}.");
        return value;
    }
}
