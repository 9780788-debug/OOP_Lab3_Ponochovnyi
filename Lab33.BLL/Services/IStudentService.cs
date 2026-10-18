using Lab33.BLL.Models;

namespace Lab33.BLL.Services;

// Сервіс студентів з додатковою операцією за варіантом.
public interface IStudentService : IEntityService<Student>
{
    // Читає файл і повертає студентів 3-го курсу, які проживають в Україні.
    IReadOnlyList<Student> ReadThirdYearFromUkraine();
}
