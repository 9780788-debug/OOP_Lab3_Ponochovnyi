using Lab33.BLL.Models;

namespace Lab33.BLL.Services;

// Контракт сервісу, який бачить рівень представлення.
public interface IEntityService<TModel> where TModel : Person
{
    // Поточні об'єкти в пам'яті.
    IReadOnlyList<TModel> Items { get; }
    // Шлях до файлу БД.
    string FilePath { get; }
    // Чи відкритий файл.
    bool IsOpen { get; }
    // Чи існує файл на диску.
    bool FileExists { get; }

    void CreateFile();
    void Open();
    void Save();
    void Close();
    void DeleteFile();

    void Add(TModel item);
    TModel Get(int index);
    void RemoveAt(int index);
    IReadOnlyList<TModel> Find(Predicate<TModel> predicate);
}
