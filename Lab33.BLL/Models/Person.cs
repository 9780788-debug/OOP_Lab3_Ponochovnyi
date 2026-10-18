using Lab33.BLL.Validation;

namespace Lab33.BLL.Models;

// Спільна база для всіх сутностей: прізвище + вміння грати в шахи.
public abstract class Person : IChessPlayer
{
    private string _surname = "";

    // Прізвище з перевіркою на порожнє значення.
    public string Surname
    {
        get => _surname;
        set => _surname = Guard.NotEmpty(value, "Прізвище");
    }

    // Базова поведінка, нащадки можуть перевизначити.
    public virtual string PlayChess() => $"{Surname} грає в шахи.";
}
