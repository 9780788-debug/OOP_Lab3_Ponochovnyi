namespace Lab33.BLL.Services;

// Формат файлу, який обирає користувач (власний enum, щоб PL не залежав від DAL).
public enum StorageFormat
{
    Json,
    Xml,
    Binary,
    Custom
}
