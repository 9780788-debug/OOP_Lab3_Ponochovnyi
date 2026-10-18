using Lab33.BLL.Exceptions;
using Lab33.BLL.Models;
using Lab33.BLL.Services;

namespace Lab33.PL.Menus;

// Спільне меню для будь-якої сутності (уникаємо дублювання коду).
public abstract class EntityMenu<TView, TModel> where TModel : Person
{
    // Сервіс рівня BLL.
    protected readonly IEntityService<TModel> Service;

    protected EntityMenu(IEntityService<TModel> service) => Service = service;

    // Заголовок меню.
    protected abstract string Title { get; }
    // Введення даних сутності з консолі.
    protected abstract TView ReadView();
    // Перетворення PL -> BLL і назад.
    protected abstract TModel ToModel(TView view);
    protected abstract TView ToView(TModel model);

    // Додаткові пункти меню (для нащадків).
    protected virtual string ExtraItems => "";
    protected virtual bool HandleExtra(string choice) => false;

    // Головний цикл меню сутності.
    public void Run()
    {
        EnsureOpen();
        while (true)
        {
            PrintMenu();
            string choice = ConsoleInput.ReadString("Ваш вибір");
            if (choice == "0") return;
            // Винятки з BLL ловимо тут, а не там, де вони виникли.
            try
            {
                if (!Handle(choice)) Console.WriteLine("Невідомий пункт меню.");
            }
            catch (EntityServiceException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }

    // Відкриває файл, а якщо його немає - створює.
    private void EnsureOpen()
    {
        if (Service.IsOpen) return;
        if (Service.FileExists) Service.Open();
        else Service.CreateFile();
    }

    // Виводить пункти меню.
    private void PrintMenu()
    {
        Console.WriteLine();
        Console.WriteLine($"--- {Title} (файл: {Service.FilePath}) ---");
        Console.WriteLine("1 - Показати всіх");
        Console.WriteLine("2 - Додати");
        Console.WriteLine("3 - Видалити");
        Console.WriteLine("4 - Пошук за прізвищем");
        Console.WriteLine("5 - Зіграти в шахи");
        Console.WriteLine("6 - Зберегти у файл");
        Console.WriteLine("7 - Зчитати з файлу");
        Console.WriteLine("8 - Створити порожній файл");
        Console.WriteLine("9 - Видалити файл");
        if (ExtraItems.Length > 0) Console.WriteLine(ExtraItems);
        Console.WriteLine("0 - Назад");
    }

    // Виконує обраний пункт; false - якщо пункт невідомий.
    private bool Handle(string choice)
    {
        switch (choice)
        {
            case "1": ShowAll(); return true;
            case "2": Service.Add(ToModel(ReadView())); Console.WriteLine("Додано."); return true;
            case "3": Remove(); return true;
            case "4": Search(); return true;
            case "5": PlayChess(); return true;
            case "6": Service.Save(); Console.WriteLine("Збережено."); return true;
            case "7": Service.Open(); Console.WriteLine("Зчитано."); return true;
            case "8": Service.CreateFile(); Console.WriteLine("Створено порожній файл."); return true;
            case "9": Service.DeleteFile(); Console.WriteLine("Файл видалено."); return true;
            default: return HandleExtra(choice);
        }
    }

    // Виводить список.
    protected void ShowAll() => PrintList(Service.Items);

    // Виводить довільний список з нумерацією.
    protected void PrintList(IReadOnlyList<TModel> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Список порожній.");
            return;
        }
        for (int i = 0; i < list.Count; i++)
            Console.WriteLine($"{i + 1}. {ToView(list[i])}");
    }

    // Видалення за номером.
    private void Remove()
    {
        ShowAll();
        int number = ConsoleInput.ReadInt("Номер для видалення");
        Service.RemoveAt(number - 1);
        Console.WriteLine("Видалено.");
    }

    // Пошук за прізвищем.
    private void Search()
    {
        string surname = ConsoleInput.ReadString("Прізвище");
        PrintList(Service.Find(p => p.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase)));
    }

    // Додаткове вміння - гра в шахи.
    private void PlayChess()
    {
        ShowAll();
        int number = ConsoleInput.ReadInt("Номер гравця");
        Console.WriteLine(Service.Get(number - 1).PlayChess());
    }
}
