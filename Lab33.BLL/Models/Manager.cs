using Lab33.BLL.Validation;

namespace Lab33.BLL.Models;

// Менеджер (рівень BLL).
public class Manager : Person
{
    private string _employeeId = "";
    private string _restaurant = "";
    private int _teamSize;

    // Табельний номер.
    public string EmployeeId
    {
        get => _employeeId;
        set => _employeeId = Guard.NotEmpty(value, "Табельний номер");
    }

    // Ресторан, яким керує менеджер.
    public string Restaurant
    {
        get => _restaurant;
        set => _restaurant = Guard.NotEmpty(value, "Ресторан");
    }

    // Розмір команди від 0 до 500.
    public int TeamSize
    {
        get => _teamSize;
        set => _teamSize = Guard.InRange(value, 0, 500, "Розмір команди");
    }

    public override string PlayChess() => $"Менеджер {Surname} грає в шахи і планує зміну на кілька ходів уперед.";
}
