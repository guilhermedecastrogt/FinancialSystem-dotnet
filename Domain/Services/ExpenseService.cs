using Domain.Interfaces.IExpense;
using Domain.Interfaces.IServices;
using Entities.Entities;

namespace Domain.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpense _iExpense;

    public ExpenseService(IExpense iExpense)
    {
        _iExpense = iExpense;
    }
    public async Task AddExpense(Expense expense)
    {
        var date = DateTime.Now;
        expense.RegisterAt = date;
        expense.Year = date.Year;
        expense.Month = date.Month;
        var valid = expense.PropertyStringValidate(expense.Name, "Name");
        if(valid)
            await _iExpense.Add(expense);
    }

    public async Task UpdateExpense(Expense expense)
    {
        var date = DateTime.Now;
        expense.UpdatedAt = date;
        
        if(expense.PaydOut)
            expense.PaymentAt = date;

        var valid = expense.PropertyStringValidate(expense.Name, "Name");
        if(valid)
            await _iExpense.Add(expense);
    }
}