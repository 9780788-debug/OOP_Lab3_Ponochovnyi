namespace Lab33.DAL.Entities;

// Сутність працівника McDonald's на рівні DAL.
public class McdonaldsWorkerEntity
{
    public string Surname { get; set; } = "";
    public string EmployeeId { get; set; } = "";
    public string Shift { get; set; } = "";
    public double HourlyRate { get; set; }
}
