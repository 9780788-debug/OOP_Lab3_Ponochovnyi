using System.Text.Json;
using Lab33.BLL.Exceptions;
using Lab33.BLL.Mapping;
using Lab33.BLL.Models;
using Lab33.DAL.Context;

namespace Lab33.BLL.Services;

// Узагальнений сервіс: додавання, видалення, пошук і робота з файлом через EntityContext.
// Тут немає Console та Stream - лише логіка.
public class EntityService<TModel, TEntity> : IEntityService<TModel>
    where TModel : Person
    where TEntity : class, new()
{
    private readonly EntityContext<TEntity> _context;
    private readonly IEntityMapper<TModel, TEntity> _mapper;
    // Об'єкти в пам'яті (робочий список).
    private List<TModel> _items = new();

    public EntityService(EntityContext<TEntity> context, IEntityMapper<TModel, TEntity> mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IReadOnlyList<TModel> Items => _items;
    public string FilePath => _context.FilePath;
    public bool IsOpen => _context.IsOpen;
    public bool FileExists => _context.Exists();

    // Створює порожній файл і очищає список.
    public void CreateFile()
    {
        Guarded(() => _context.Create());
        _items = new List<TModel>();
    }

    // Читає файл і перетворює сутності DAL на моделі.
    public void Open()
    {
        Guarded(() => _context.Open());
        _items = _context.Items.Select(_mapper.ToModel).ToList();
    }

    // Записує поточний список у файл.
    public void Save() =>
        Guarded(() => _context.Update(_items.Select(_mapper.ToEntity).ToList()));

    // Закриває файл.
    public void Close()
    {
        _context.Close();
        _items = new List<TModel>();
    }

    // Видаляє файл з диска.
    public void DeleteFile()
    {
        Guarded(() => _context.Delete());
        _items = new List<TModel>();
    }

    // Додає об'єкт у список.
    public void Add(TModel item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
    }

    // Повертає об'єкт за індексом (з 0).
    public TModel Get(int index)
    {
        CheckIndex(index);
        return _items[index];
    }

    // Видаляє об'єкт за індексом (з 0).
    public void RemoveAt(int index)
    {
        CheckIndex(index);
        _items.RemoveAt(index);
    }

    // Пошук за довільною умовою.
    public IReadOnlyList<TModel> Find(Predicate<TModel> predicate) => _items.FindAll(predicate);

    // Перевірка індексу.
    private void CheckIndex(int index)
    {
        if (index < 0 || index >= _items.Count)
            throw new EntityNotFoundException($"Об'єкта з номером {index + 1} не існує.");
    }

    // Перетворює технічні помилки файлу на власний виняток (обробка - у PL).
    private static void Guarded(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException
                                      or InvalidOperationException or JsonException
                                      or FormatException or OverflowException
                                      or InvalidDataException or InvalidCastException)
        {
            throw new StorageException($"Помилка роботи з файлом: {ex.Message}", ex);
        }
    }
}
