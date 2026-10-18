using Lab33.BLL.Models;
using Lab33.PL.Views;

namespace Lab33.PL.Mapping;

// Перетворення WorkerView <-> McdonaldsWorker (BLL).
public static class WorkerViewMapper
{
    public static McdonaldsWorker ToModel(WorkerView v) => new()
    {
        Surname = v.Surname,
        EmployeeId = v.EmployeeId,
        Shift = v.Shift,
        HourlyRate = v.HourlyRate
    };

    public static WorkerView ToView(McdonaldsWorker m) => new()
    {
        Surname = m.Surname,
        EmployeeId = m.EmployeeId,
        Shift = m.Shift,
        HourlyRate = m.HourlyRate
    };
}
