using Lab33.BLL.Validation;

namespace Lab33.BLL.Models;

// Студент (рівень BLL).
public class Student : Person
{
    private int _course;
    private double _averageScore;
    private string _studentCardNumber = "";
    private string _country = "";
    private string _gradeBookNumber = "";

    // Курс від 1 до 6.
    public int Course
    {
        get => _course;
        set => _course = Guard.InRange(value, 1, 6, "Курс");
    }

    // Номер студентського квитка.
    public string StudentCardNumber
    {
        get => _studentCardNumber;
        set => _studentCardNumber = Guard.NotEmpty(value, "Номер студентського квитка");
    }

    // Середній бал від 0 до 100.
    public double AverageScore
    {
        get => _averageScore;
        set => _averageScore = Guard.InRange(value, 0, 100, "Середній бал");
    }

    // Країна проживання.
    public string Country
    {
        get => _country;
        set => _country = Guard.NotEmpty(value, "Країна");
    }

    // Номер залікової книжки.
    public string GradeBookNumber
    {
        get => _gradeBookNumber;
        set => _gradeBookNumber = Guard.NotEmpty(value, "Номер залікової книжки");
    }

    public override string PlayChess() => $"Студент {Surname} грає в шахи між парами.";
}
