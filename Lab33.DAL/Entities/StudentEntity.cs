namespace Lab33.DAL.Entities;

// Сутність студента на рівні DAL (лише дані).
public class StudentEntity
{
    public string Surname { get; set; } = "";
    public int Course { get; set; }
    public string StudentCardNumber { get; set; } = "";
    public double AverageScore { get; set; }
    public string Country { get; set; } = "";
    public string GradeBookNumber { get; set; } = "";
}
