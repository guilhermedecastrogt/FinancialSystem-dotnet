using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.IFinancialSystemUser
{
    public interface IFinancialSystemUser : InterfaceGeneric<FinancialSystemUser>
    {
        Task<IList<FinancialSystemUser>> ListFinancialSystemUser(int idSystem);
        Task RemoveUser(List<FinancialSystemUser> usersList);
        Task<FinancialSystemUser> GetUserByEmail(string userEmail);
    }
}