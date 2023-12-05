using Domain.Interfaces.IFinancialSystemUser;
using Entities.Entities;
using Infra.Configuracao;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class FinancialSystemUserRepository : 
    RepositoryGenerics<FinancialSystemUser>, 
    IFinancialSystemUser
{
    private readonly DbContextOptions<ContextBase> _context;

    public FinancialSystemUserRepository()
    {
        _context = new DbContextOptions<ContextBase>();
    }
    public async Task<IList<FinancialSystemUser>> ListFinancialSystemUser(int idSystem)
    {
        using (var context = new ContextBase(_context))
        {
            return await context.FinancialSystemUser
                .Where(x => x.IdSystem == idSystem)
                .AsNoTracking().ToListAsync();
        }
    }

    public async Task RemoveUser(List<FinancialSystemUser> usersList)
    {
        using (var context = new ContextBase(_context))
        {
            context.FinancialSystemUser.RemoveRange(usersList);
            await context.SaveChangesAsync();
        }
    }

    public async Task<FinancialSystemUser> GetUserByEmail(string userEmail)
    {
        using (var context = new ContextBase(_context))
        {
            var find = context.FinancialSystemUser
                .AsNoTracking().FirstOrDefaultAsync(x => x.UserEmail.Equals(userEmail));
            return await find;
        }
    }
}