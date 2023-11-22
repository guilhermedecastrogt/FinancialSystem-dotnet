using Domain.Interfaces.IFinancialSystem;
using Entities.Entities;
using Infra.Repository.Generics;

namespace Infra.Repository;

public class FinancialSystemRepository : RepositoryGenerics<FinancialSystem>, IFinancialSystem
{
    public Task<IList<FinancialSystem>> ListFinancialSystemUser(string userEmail)
    {
        throw new NotImplementedException();
    }
}