using Lab33.BLL.Mapping;
using Lab33.BLL.Models;
using Lab33.DAL.Context;
using Lab33.DAL.Entities;

namespace Lab33.BLL.Services;

// Сервіс студентів: додаткова операція за варіантом 5.
public class StudentService : EntityService<Student, StudentEntity>, IStudentService
{
    public StudentService(EntityContext<StudentEntity> context, IEntityMapper<Student, StudentEntity> mapper)
        : base(context, mapper) { }

    // Читає дані з файлу і відбирає студентів 3-го курсу з України.
    public IReadOnlyList<Student> ReadThirdYearFromUkraine()
    {
        Open();
        return Find(IsThirdYearFromUkraine);
    }

    // Умова відбору.
    private static bool IsThirdYearFromUkraine(Student s) =>
        s.Course == 3 &&
        (string.Equals(s.Country, "Україна", StringComparison.OrdinalIgnoreCase) ||
         string.Equals(s.Country, "Ukraine", StringComparison.OrdinalIgnoreCase));
}
