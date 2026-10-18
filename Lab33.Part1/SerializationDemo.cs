namespace Lab33.Part1;

// Демонстрація одного способу серіалізації (завдання 2-4).
public static class SerializationDemo
{
    public static void Run(IRectangleSerializer serializer, Rectangle[] source)
    {
        Console.WriteLine($"=== {serializer.Name} ===");

        // Завдання 2: масив -> файл.
        string arrayFile = $"rectangles_array{serializer.Extension}";
        serializer.Save(arrayFile, source);
        Console.WriteLine($"[2] Масив з {source.Length} об'єктів записано у {arrayFile}");

        // Завдання 3: новий масив <- файл.
        Rectangle[] restoredArray = serializer.Load(arrayFile).ToArray();
        Console.WriteLine($"[3] Відновлений масив ({restoredArray.Length} об'єктів):");
        PrintAll(restoredArray);

        // Завдання 4: колекція List -> файл -> нова колекція.
        List<Rectangle> sourceList = source.ToList();
        string listFile = $"rectangles_list{serializer.Extension}";
        serializer.Save(listFile, sourceList);
        List<Rectangle> restoredList = serializer.Load(listFile);
        Console.WriteLine($"[4] Колекцію List записано у {listFile}, відновлено {restoredList.Count} об'єктів");

        // Порівняння масиву і колекції.
        bool sameObjects = restoredArray.Length == restoredList.Count &&
                           restoredArray.Zip(restoredList, (a, b) => a.IsSameAs(b)).All(x => x);
        bool sameFiles = File.ReadAllBytes(arrayFile).SequenceEqual(File.ReadAllBytes(listFile));
        bool sameAsSource = source.Zip(restoredArray, (a, b) => a.IsSameAs(b)).All(x => x);
        Console.WriteLine($"[4] Масив == колекція (об'єкти): {sameObjects}");
        Console.WriteLine($"[4] Масив == колекція (вміст файлів): {sameFiles}");
        Console.WriteLine($"[4] Відновлені дані == початкові: {sameAsSource}");
        Console.WriteLine();
    }

    // Виводить інформацію про кожен прямокутник.
    private static void PrintAll(IEnumerable<Rectangle> items)
    {
        int i = 1;
        foreach (var r in items)
            Console.WriteLine($"    {i++}. {r.GetInfo()}");
    }
}
