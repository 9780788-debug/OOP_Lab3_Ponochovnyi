using Lab33.BLL.Models;
using Lab33.DAL.Entities;

namespace Lab33.BLL.Mapping;

public class McdonaldsWorkerMapper : IEntityMapper<McdonaldsWorker, McdonaldsWorkerEntity>
{
    // Модель -> сутність DAL.
    public McdonaldsWorkerEntity ToEntity(McdonaldsWorker m) => new()
    {
        Surname = m.Surname,
        EmployeeId = m.EmployeeId,
        Shift = m.Shift,
        HourlyRate = m.HourlyRate
    };

    // Сутність DAL -> модель.
    public McdonaldsWorker ToModel(McdonaldsWorkerEntity e) => new()
    {
        Surname = e.Surname,
        EmployeeId = e.EmployeeId,
        Shift = e.Shift,
        HourlyRate = e.HourlyRate
    };
}
