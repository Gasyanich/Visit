namespace Visit.Domain.BL.Abstractions.Repository;

public interface IAttributeRepository
{
    Task<bool> IsExistByName(string name);
    Task<Attribute> Create(Attribute category);
    Task<Attribute> GetById(int id);
    Task<List<Attribute>> GetAll();
    Task Delete(int id);
    Task<Attribute> Update(Attribute attribute);
}