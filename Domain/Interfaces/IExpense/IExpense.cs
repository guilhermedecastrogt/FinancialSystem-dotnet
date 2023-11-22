using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.IExpense
{
    public interface IExpense : InterfaceGeneric<Expense>
    {
        Task<IList<Expense>> ExpenseUserList (string userEmail);
        Task<IList<Expense>> UnpaidExpenseUserList (string userEmail);
    }
}
