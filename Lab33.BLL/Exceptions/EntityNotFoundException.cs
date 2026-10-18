namespace Lab33.BLL.Exceptions;

// Сутність за вказаним номером не знайдена.
public class EntityNotFoundException : EntityServiceException
{
    public EntityNotFoundException(string message) : base(message) { }
}
