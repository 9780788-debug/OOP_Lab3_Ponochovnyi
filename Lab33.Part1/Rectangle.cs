using System.Globalization;

namespace Lab33.Part1;

// Клас, що серіалізується (варіант 5: прямокутник).
[Serializable]
public class Rectangle
{
    // Колір заливки.
    public string FillColor { get; set; } = "";
    // Колір контуру.
    public string OutlineColor { get; set; } = "";
    // Довжини сторін.
    public double Width { get; set; }
    public double Height { get; set; }

    // Порожній конструктор потрібен XML/JSON серіалізаторам.
    public Rectangle() { }

    // Конструктор для зручного створення об'єктів.
    public Rectangle(string fillColor, string outlineColor, double width, double height)
    {
        FillColor = fillColor;
        OutlineColor = outlineColor;
        Width = width;
        Height = height;
    }

    // Площа = a * b.
    public double GetArea() => Width * Height;

    // Периметр = 2 * (a + b).
    public double GetPerimeter() => 2 * (Width + Height);

    // Інформація про фігуру одним рядком.
    public string GetInfo() =>
        string.Format(CultureInfo.InvariantCulture,
            "Rectangle: fill={0}, outline={1}, {2}x{3}, area={4:F2}, perimeter={5:F2}",
            FillColor, OutlineColor, Width, Height, GetArea(), GetPerimeter());

    // Порівняння за значеннями полів (для перевірки відновлення).
    public bool IsSameAs(Rectangle other) =>
        FillColor == other.FillColor && OutlineColor == other.OutlineColor &&
        Width == other.Width && Height == other.Height;
}
