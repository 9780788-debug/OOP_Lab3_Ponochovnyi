namespace Lab33.PL.Views;

// Студент на рівні представлення.
public class StudentView
{
    public string Surname { get; set; } = "";
    public int Course { get; set; }
    public string StudentCardNumber { get; set; } = "";
    public double AverageScore { get; set; }
    public string Country { get; set; } = "";
    public string GradeBookNumber { get; set; } = "";

    // Рядок для виводу в консоль.
    public override string ToString() =>
        $"{Surname}, курс {Course}, квиток {StudentCardNumber}, бал {AverageScore:F1}, " +
        $"країна {Country}, залікова {GradeBookNumber}";
}
