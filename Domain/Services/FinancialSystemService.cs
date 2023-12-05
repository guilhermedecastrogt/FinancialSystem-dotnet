using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IServices;
using Entities.Entities;

namespace Domain.Services;

public class FinancialSystemService : IFinancialSystemService
{
    private readonly IFinancialSystem _iFinancialSystem;
    
    public FinancialSystemService(IFinancialSystem iFinancialSystem)
    {
        _iFinancialSystem = iFinancialSystem;
    }
    
    
    public async Task AddFinancialSystem(FinancialSystem financialSystem)
    {
        var valid = financialSystem.PropertyStringValidate(financialSystem.Name, "Name");

        if (valid)
        {
            var date = DateTime.Now;

            financialSystem.CloseDay = 1;
            financialSystem.Year = date.Year;
            financialSystem.Month = date.Month;
            financialSystem.YearCopy = date.Year;
            financialSystem.MonthCopy = date.Month;
            financialSystem.ExpenseCopyToGenerate = true;
            
            await _iFinancialSystem.Add(financialSystem);
        }
            
    }

    public async Task UpdateFinancialSystem(FinancialSystem financialSystem)
    {
        var valid = financialSystem.PropertyStringValidate(financialSystem.Name, "Name");

        if (valid)
        {
            financialSystem.CloseDay = 1;
            await _iFinancialSystem.Update(financialSystem);
        }
    }
}