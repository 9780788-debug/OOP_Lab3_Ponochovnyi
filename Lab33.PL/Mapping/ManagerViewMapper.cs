using Lab33.BLL.Models;
using Lab33.PL.Views;

namespace Lab33.PL.Mapping;

// Перетворення ManagerView <-> Manager (BLL).
public static class ManagerViewMapper
{
    public static Manager ToModel(ManagerView v) => new()
    {
        Surname = v.Surname,
        EmployeeId = v.EmployeeId,
        Restaurant = v.Restaurant,
        TeamSize = v.TeamSize
    };

    public static ManagerView ToView(Manager m) => new()
    {
        Surname = m.Surname,
        EmployeeId = m.EmployeeId,
        Restaurant = m.Restaurant,
        TeamSize = m.TeamSize
    };
}
