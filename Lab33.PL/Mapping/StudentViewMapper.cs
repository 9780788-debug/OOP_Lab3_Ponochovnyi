using Lab33.BLL.Models;
using Lab33.PL.Views;

namespace Lab33.PL.Mapping;

// Перетворення StudentView <-> Student (BLL).
public static class StudentViewMapper
{
    // Тут спрацьовує валідація моделі BLL.
    public static Student ToModel(StudentView v) => new()
    {
        Surname = v.Surname,
        Course = v.Course,
        StudentCardNumber = v.StudentCardNumber,
        AverageScore = v.AverageScore,
        Country = v.Country,
        GradeBookNumber = v.GradeBookNumber
    };

    public static StudentView ToView(Student m) => new()
    {
        Surname = m.Surname,
        Course = m.Course,
        StudentCardNumber = m.StudentCardNumber,
        AverageScore = m.AverageScore,
        Country = m.Country,
        GradeBookNumber = m.GradeBookNumber
    };
}
