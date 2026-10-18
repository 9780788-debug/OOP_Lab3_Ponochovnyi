using Lab33.BLL.Models;
using Lab33.BLL.Services;
using Lab33.PL.Mapping;
using Lab33.PL.Views;

namespace Lab33.PL.Menus;

// Меню студентів + операція за варіантом 5.
public class StudentMenu : EntityMenu<StudentView, Student>
{
    private readonly IStudentService _students;

    public StudentMenu(IStudentService service) : base(service) => _students = service;

    protected override string Title => "Студенти";
    protected override string ExtraItems => "10 - Студенти 3-го курсу з України (з файлу)";

    // Вводимо поля студента по черзі.
    protected override StudentView ReadView() => new()
    {
        Surname = ConsoleInput.ReadString("Прізвище"),
        Course = ConsoleInput.ReadInt("Курс (1-6)"),
        StudentCardNumber = ConsoleInput.ReadString("Номер студентського квитка"),
        AverageScore = ConsoleInput.ReadDouble("Середній бал (0-100)"),
        Country = ConsoleInput.ReadString("Країна"),
        GradeBookNumber = ConsoleInput.ReadString("Номер залікової книжки")
    };

    protected override Student ToModel(StudentView view) => StudentViewMapper.ToModel(view);
    protected override StudentView ToView(Student model) => StudentViewMapper.ToView(model);

    // Пункт 10: кількість і дані студентів 3-го курсу з України.
    protected override bool HandleExtra(string choice)
    {
        if (choice != "10") return false;
        var result = _students.ReadThirdYearFromUkraine();
        Console.WriteLine($"Кількість студентів 3-го курсу з України: {result.Count}");
        PrintList(result);
        return true;
    }
}
