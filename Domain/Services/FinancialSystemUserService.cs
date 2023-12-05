using Domain.Interfaces.IFinancialSystemUser;
using Domain.Interfaces.IServices;
using Entities.Entities;

namespace Domain.Services;

public class FinancialSystemUserService : IFinancialSystemUserService
{
    private readonly IFinancialSystemUser _iFinancialSystemUser;
    public FinancialSystemUserService(IFinancialSystemUser iFinancialSystemUser)
    {
        _iFinancialSystemUser = iFinancialSystemUser;
    }
    
    public async Task RegisterUserInSystem(FinancialSystemUser userServiceSystem)
    {
        await _iFinancialSystemUser.Add(userServiceSystem);
    }
}