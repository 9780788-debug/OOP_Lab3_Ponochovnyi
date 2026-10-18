namespace Lab33.Part1;

// Створює вихідні дані (5 об'єктів за варіантом).
public static class RectangleFactory
{
    public static Rectangle[] CreateSample() => new[]
    {
        new Rectangle("Red", "Black", 3, 4),
        new Rectangle("Green", "White", 5, 2.5),
        new Rectangle("Blue", "Yellow", 10, 7),
        new Rectangle("Orange", "Gray", 1.5, 1.5),
        new Rectangle("Purple", "Pink", 8, 6)
    };
}
