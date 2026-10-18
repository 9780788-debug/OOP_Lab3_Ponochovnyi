namespace Lab33.BLL.Exceptions;

// Некоректні дані сутності (порожнє прізвище, курс поза межами тощо).
public class InvalidEntityDataException : EntityServiceException
{
    public InvalidEntityDataException(string message) : base(message) { }
}
