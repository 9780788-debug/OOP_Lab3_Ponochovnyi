namespace Lab33.PL.Views;

// Менеджер на рівні представлення.
public class ManagerView
{
    public string Surname { get; set; } = "";
    public string EmployeeId { get; set; } = "";
    public string Restaurant { get; set; } = "";
    public int TeamSize { get; set; }

    public override string ToString() =>
        $"{Surname}, таб.№ {EmployeeId}, ресторан {Restaurant}, команда {TeamSize}";
}
