using Lab33.BLL.Validation;

namespace Lab33.BLL.Models;

// Працівник McDonald's (рівень BLL).
public class McdonaldsWorker : Person
{
    private string _employeeId = "";
    private string _shift = "";
    private double _hourlyRate;

    // Табельний номер.
    public string EmployeeId
    {
        get => _employeeId;
        set => _employeeId = Guard.NotEmpty(value, "Табельний номер");
    }

    // Зміна (наприклад, "ранкова").
    public string Shift
    {
        get => _shift;
        set => _shift = Guard.NotEmpty(value, "Зміна");
    }

    // Погодинна ставка від 0 до 10000.
    public double HourlyRate
    {
        get => _hourlyRate;
        set => _hourlyRate = Guard.InRange(value, 0, 10000, "Погодинна ставка");
    }

    public override string PlayChess() => $"Працівник {Surname} грає в шахи під час перерви.";
}
