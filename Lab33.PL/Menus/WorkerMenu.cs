using Lab33.BLL.Models;
using Lab33.BLL.Services;
using Lab33.PL.Mapping;
using Lab33.PL.Views;

namespace Lab33.PL.Menus;

// Меню працівників McDonald's.
public class WorkerMenu : EntityMenu<WorkerView, McdonaldsWorker>
{
    public WorkerMenu(IEntityService<McdonaldsWorker> service) : base(service) { }

    protected override string Title => "Працівники McDonald's";

    protected override WorkerView ReadView() => new()
    {
        Surname = ConsoleInput.ReadString("Прізвище"),
        EmployeeId = ConsoleInput.ReadString("Табельний номер"),
        Shift = ConsoleInput.ReadString("Зміна"),
        HourlyRate = ConsoleInput.ReadDouble("Погодинна ставка")
    };

    protected override McdonaldsWorker ToModel(WorkerView view) => WorkerViewMapper.ToModel(view);
    protected override WorkerView ToView(McdonaldsWorker model) => WorkerViewMapper.ToView(model);
}
