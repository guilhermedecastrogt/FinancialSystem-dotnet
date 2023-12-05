using Domain.Interfaces.IExpense;
using Entities.Entities;
using Infra.Configuracao;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class ExpenseRepository : RepositoryGenerics<Expense>, IExpense
{
    private readonly DbContextOptions<ContextBase> _context;

    public ExpenseRepository()
    {
        _context = new DbContextOptions<ContextBase>();
    }
    
    public async Task<IList<Expense>> ExpenseUserList(string userEmail)
    {
        using (var context = new ContextBase(_context))
        {
            return await
                (from s in context.FinancialSystem
                    join c in context.Category on s.Id equals c.SystemId
                    join us in context.FinancialSystemUser on s.Id equals us.IdSystem
                    join d in context.Expense on c.Id equals d.IdCategory
                    where us.UserEmail.Equals(userEmail) && s.Month == d.Month && s.Year == d.Year
                    select d)
                .AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<Expense>> UnpaidExpenseUserList(string userEmail)
    {
        using (var context = new ContextBase(_context))
        {
            return await
                (from s in context.FinancialSystem
                    join c in context.Category on s.Id equals c.SystemId
                    join us in context.FinancialSystemUser on s.Id equals us.IdSystem
                    join d in context.Expense on c.Id equals d.IdCategory
                    where us.UserEmail.Equals(userEmail) && d.Month < DateTime.Now.Month && !d.PaydOut
                    select d)
                .AsNoTracking().ToListAsync();
        }
    }
} 