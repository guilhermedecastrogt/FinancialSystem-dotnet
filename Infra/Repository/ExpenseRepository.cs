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
    
    public Task<IList<Expense>> ExpenseUserList(string userEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Expense>> UnpaidExpenseUserList(string userEmail)
    {
        throw new NotImplementedException();
    }
}