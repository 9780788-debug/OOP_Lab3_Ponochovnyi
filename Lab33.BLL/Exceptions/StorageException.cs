namespace Lab33.BLL.Exceptions;

// Помилка роботи з файлом (читання, запис, формат).
public class StorageException : EntityServiceException
{
    public StorageException(string message, Exception inner) : base(message, inner) { }
}
