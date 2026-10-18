using System.Text;
using Lab33.BLL.Exceptions;
using Lab33.BLL.Services;
using Lab33.PL.Menus;

namespace Lab33.PL;

// Головне меню (рівень представлення) в окремому проєкті.
public static class Menu
{
    // Підменю сутностей створюються після вибору формату і імені файлу.
    private static StudentMenu? _students;
    private static WorkerMenu? _workers;
    private static ManagerMenu? _managers;

    // Єдиний метод, який викликає Main().
    public static void MainMenu()
    {
        // Кирилиця в консолі.
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        ConfigureStorage();
        while (true)
        {
            PrintMenu();
            string choice = ConsoleInput.ReadString("Ваш вибір");
            if (choice == "0") return;
            // Обробка винятків BLL відбувається тут.
            try
            {
                if (!Dispatch(choice)) Console.WriteLine("Невідомий пункт меню.");
            }
            catch (EntityServiceException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }

    // Виводить пункти головного меню.
    private static void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== Головне меню ===");
        Console.WriteLine("1 - Студенти");
        Console.WriteLine("2 - Працівники McDonald's");
        Console.WriteLine("3 - Менеджери");
        Console.WriteLine("4 - Змінити формат / ім'я файлу");
        Console.WriteLine("0 - Вихід");
    }

    // Запускає обране підменю.
    private static bool Dispatch(string choice)
    {
        switch (choice)
        {
            case "1": _students!.Run(); return true;
            case "2": _workers!.Run(); return true;
            case "3": _managers!.Run(); return true;
            case "4": ConfigureStorage(); return true;
            default: return false;
        }
    }

    // Просить обрати формат та ім'я файлу, повторює при помилці.
    private static void ConfigureStorage()
    {
        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Формат файлу: 1 - JSON, 2 - XML, 3 - Binary, 4 - Custom");
                StorageFormat format = ReadFormat(ConsoleInput.ReadInt("Оберіть формат"));
                string name = ConsoleInput.ReadString("Ім'я файлу без розширення (можна з папкою)");
                if (name.Length == 0) throw new InvalidEntityDataException("Ім'я файлу не може бути порожнім.");

                // Назва і формат передаються з PL на нижчі рівні.
                _students = new StudentMenu(ServiceFactory.CreateStudentService(format, name));
                _workers = new WorkerMenu(ServiceFactory.CreateWorkerService(format, name));
                _managers = new ManagerMenu(ServiceFactory.CreateManagerService(format, name));
                Console.WriteLine($"Формат: {format}, файли: {name}_students / _workers / _managers");
                return;
            }
            catch (EntityServiceException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }

    // Номер пункту -> формат.
    private static StorageFormat ReadFormat(int number) => number switch
    {
        1 => StorageFormat.Json,
        2 => StorageFormat.Xml,
        3 => StorageFormat.Binary,
        4 => StorageFormat.Custom,
        _ => throw new InvalidEntityDataException("Формат має бути від 1 до 4.")
    };
}
