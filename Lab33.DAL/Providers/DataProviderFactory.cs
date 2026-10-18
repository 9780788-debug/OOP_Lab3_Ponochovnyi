namespace Lab33.DAL.Providers;

// Створює провайдер за обраним форматом.
public static class DataProviderFactory
{
    public static DataProvider<T> Create<T>(DataFormat format) where T : class, new() => format switch
    {
        DataFormat.Json => new JsonDataProvider<T>(),
        DataFormat.Xml => new XmlDataProvider<T>(),
        DataFormat.Binary => new BinaryDataProvider<T>(),
        DataFormat.Custom => new CustomDataProvider<T>(),
        _ => throw new ArgumentOutOfRangeException(nameof(format))
    };
}
