using Lab33.BLL.Models;
using Lab33.DAL.Entities;

namespace Lab33.BLL.Mapping;

public class ManagerMapper : IEntityMapper<Manager, ManagerEntity>
{
    // Модель -> сутність DAL.
    public ManagerEntity ToEntity(Manager m) => new()
    {
        Surname = m.Surname,
        EmployeeId = m.EmployeeId,
        Restaurant = m.Restaurant,
        TeamSize = m.TeamSize
    };

    // Сутність DAL -> модель.
    public Manager ToModel(ManagerEntity e) => new()
    {
        Surname = e.Surname,
        EmployeeId = e.EmployeeId,
        Restaurant = e.Restaurant,
        TeamSize = e.TeamSize
    };
}
