using Lab33.BLL.Mapping;
using Lab33.BLL.Models;
using Lab33.DAL.Context;
using Lab33.DAL.Entities;
using Lab33.DAL.Providers;

namespace Lab33.BLL.Services;

// Збирає сервіси: провайдер + контекст + мапер. Ім'я файлу і формат приходять з PL.
public static class ServiceFactory
{
    public static IStudentService CreateStudentService(StorageFormat format, string baseName)
    {
        var provider = DataProviderFactory.Create<StudentEntity>(ToDataFormat(format));
        var context = new EntityContext<StudentEntity>(provider, baseName + "_students" + provider.Extension);
        return new StudentService(context, new StudentMapper());
    }

    public static IEntityService<McdonaldsWorker> CreateWorkerService(StorageFormat format, string baseName)
    {
        var provider = DataProviderFactory.Create<McdonaldsWorkerEntity>(ToDataFormat(format));
        var context = new EntityContext<McdonaldsWorkerEntity>(provider, baseName + "_workers" + provider.Extension);
        return new EntityService<McdonaldsWorker, McdonaldsWorkerEntity>(context, new McdonaldsWorkerMapper());
    }

    public static IEntityService<Manager> CreateManagerService(StorageFormat format, string baseName)
    {
        var provider = DataProviderFactory.Create<ManagerEntity>(ToDataFormat(format));
        var context = new EntityContext<ManagerEntity>(provider, baseName + "_managers" + provider.Extension);
        return new EntityService<Manager, ManagerEntity>(context, new ManagerMapper());
    }

    // Формат BLL -> формат DAL.
    private static DataFormat ToDataFormat(StorageFormat format) => format switch
    {
        StorageFormat.Json => DataFormat.Json,
        StorageFormat.Xml => DataFormat.Xml,
        StorageFormat.Binary => DataFormat.Binary,
        StorageFormat.Custom => DataFormat.Custom,
        _ => throw new ArgumentOutOfRangeException(nameof(format))
    };
}
