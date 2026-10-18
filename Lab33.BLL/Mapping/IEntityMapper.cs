using Lab33.BLL.Models;

namespace Lab33.BLL.Mapping;

// Перетворення між моделлю BLL і сутністю DAL.
public interface IEntityMapper<TModel, TEntity> where TModel : Person
{
    TEntity ToEntity(TModel model);
    TModel ToModel(TEntity entity);
}
