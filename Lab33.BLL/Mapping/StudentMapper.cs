using Lab33.BLL.Models;
using Lab33.DAL.Entities;

namespace Lab33.BLL.Mapping;

public class StudentMapper : IEntityMapper<Student, StudentEntity>
{
    // Модель -> сутність DAL.
    public StudentEntity ToEntity(Student m) => new()
    {
        Surname = m.Surname,
        Course = m.Course,
        StudentCardNumber = m.StudentCardNumber,
        AverageScore = m.AverageScore,
        Country = m.Country,
        GradeBookNumber = m.GradeBookNumber
    };

    // Сутність DAL -> модель (сеттери перевіряють дані з файлу).
    public Student ToModel(StudentEntity e) => new()
    {
        Surname = e.Surname,
        Course = e.Course,
        StudentCardNumber = e.StudentCardNumber,
        AverageScore = e.AverageScore,
        Country = e.Country,
        GradeBookNumber = e.GradeBookNumber
    };
}
