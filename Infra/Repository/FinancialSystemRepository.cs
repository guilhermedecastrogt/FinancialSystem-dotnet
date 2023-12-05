using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infra.Configuracao;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class FinancialSystemRepository : RepositoryGenerics<FinancialSystem>, IFinancialSystem
{
    private readonly DbContextOptions<ContextBase> _context;

    public FinancialSystemRepository()
    {
        _context = new DbContextOptions<ContextBase>();
    }
    public async Task<IList<FinancialSystem>> ListFinancialSystemUser(string userEmail)
    {
        using (var context = new ContextBase(_context))
        {
            return await
                (from s in context.FinancialSystem
                    join us in context.FinancialSystemUser on s.Id equals us.IdSystem
                    where us.UserEmail.Equals(userEmail)
                    select s)
                .AsNoTracking().ToListAsync();
        }
    }
}