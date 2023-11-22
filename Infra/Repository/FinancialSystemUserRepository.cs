using Domain.Interfaces.IFinancialSystemUser;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository;

public class FinancialSystemUserRepository : 
    RepositoryGenerics<FinancialSystemUser>, 
    IFinancialSystemUser
{
    public Task<IList<FinancialSystemUser>> ListFinancialSystemUser(string userEmail)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUser(List<FinancialSystemUser> usersList)
    {
        throw new NotImplementedException();
    }

    public Task<FinancialSystemUser> GetUserByEmail(string userEmail)
    {
        throw new NotImplementedException();
    }
}