namespace Visit.Domain.BL.Abstractions.Repository;

public interface ICategoryRepository
{
    Task<bool> IsExistByName(string name);
    Task<Category> Create(Category category);
    Task<Category> GetById(int id);
    Task<IEnumerable<Category>> GetByIds(IEnumerable<int> ids);
    Task<List<Category>> GetAll();
    Task Delete(int id);
    Task Update(Category category);
}