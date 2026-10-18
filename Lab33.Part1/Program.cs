using System.Text;

namespace Lab33.Part1;

internal static class Program
{
    private static void Main()
    {
        // Кирилиця в консолі.
        Console.OutputEncoding = Encoding.UTF8;

        // Завдання 1: створюємо початковий масив.
        Rectangle[] source = RectangleFactory.CreateSample();
        Console.WriteLine("[1] Початковий масив прямокутників:");
        for (int i = 0; i < source.Length; i++)
            Console.WriteLine($"    {i + 1}. {source[i].GetInfo()}");
        Console.WriteLine();

        // Завдання 5: усі чотири способи серіалізації.
        IRectangleSerializer[] serializers =
        {
            new BinaryRectangleSerializer(),
            new CustomRectangleSerializer(),
            new XmlRectangleSerializer(),
            new JsonRectangleSerializer()
        };
        foreach (var serializer in serializers)
            SerializationDemo.Run(serializer, source);

        Console.WriteLine("Файли збережено поруч з exe (bin/Debug/net8.0).");
    }
}
