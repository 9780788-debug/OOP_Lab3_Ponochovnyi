namespace Lab33.PL.Views;

// Працівник McDonald's на рівні представлення.
public class WorkerView
{
    public string Surname { get; set; } = "";
    public string EmployeeId { get; set; } = "";
    public string Shift { get; set; } = "";
    public double HourlyRate { get; set; }

    public override string ToString() =>
        $"{Surname}, таб.№ {EmployeeId}, зміна {Shift}, ставка {HourlyRate:F2}";
}
