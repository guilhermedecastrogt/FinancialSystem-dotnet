using Domain.Interfaces.ICategory;
using Entities.Entities;
using Infra.Configuracao;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class CategoryRepository : RepositoryGenerics<Category>, ICategory
{
    private readonly DbContextOptions<ContextBase> _context;

    public CategoryRepository()
    {
        _context = new DbContextOptions<ContextBase>();
    }
    public async Task<IList<Category>> ListCategoryUser(string userEmail)
    {
        using(var context = new ContextBase(_context))
        {
            return await
                (from s in context.FinancialSystem
                    join c in context.Category on s.Id equals c.SystemId
                    join us in context.FinancialSystemUser on s.Id equals us.IdSystem
                    where us.UserEmail.Equals(userEmail) && us.CurrentSystem
                    select c)
                .AsNoTracking().ToListAsync();
        }
    }
}