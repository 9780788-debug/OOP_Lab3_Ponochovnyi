using Lab33.BLL.Models;
using Lab33.BLL.Services;
using Lab33.PL.Mapping;
using Lab33.PL.Views;

namespace Lab33.PL.Menus;

// Меню менеджерів.
public class ManagerMenu : EntityMenu<ManagerView, Manager>
{
    public ManagerMenu(IEntityService<Manager> service) : base(service) { }

    protected override string Title => "Менеджери";

    protected override ManagerView ReadView() => new()
    {
        Surname = ConsoleInput.ReadString("Прізвище"),
        EmployeeId = ConsoleInput.ReadString("Табельний номер"),
        Restaurant = ConsoleInput.ReadString("Ресторан"),
        TeamSize = ConsoleInput.ReadInt("Розмір команди")
    };

    protected override Manager ToModel(ManagerView view) => ManagerViewMapper.ToModel(view);
    protected override ManagerView ToView(Manager model) => ManagerViewMapper.ToView(model);
}
