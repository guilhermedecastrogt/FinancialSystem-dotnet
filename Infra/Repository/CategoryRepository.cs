using Domain.Interfaces.ICategory;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository;

public class CategoryRepository : RepositoryGenerics<Category>, ICategory
{
    public Task<IList<Category>> ListCategoryUser(string userEmail)
    {
        throw new NotImplementedException();
    }
}