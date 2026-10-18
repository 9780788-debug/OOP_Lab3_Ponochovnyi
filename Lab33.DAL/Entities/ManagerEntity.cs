namespace Lab33.DAL.Entities;

// Сутність менеджера на рівні DAL.
public class ManagerEntity
{
    public string Surname { get; set; } = "";
    public string EmployeeId { get; set; } = "";
    public string Restaurant { get; set; } = "";
    public int TeamSize { get; set; }
}
