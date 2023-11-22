using Domain.Interfaces.IExpense;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository;

public class ExpenseRepository : RepositoryGenerics<Expense>, IExpense
{
    public Task<IList<Expense>> ExpenseUserList(string userEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Expense>> UnpaidExpenseUserList(string userEmail)
    {
        throw new NotImplementedException();
    }
}