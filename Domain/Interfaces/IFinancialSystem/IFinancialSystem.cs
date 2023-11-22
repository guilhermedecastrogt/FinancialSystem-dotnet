using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.IFinancialSystem
{
    public interface IFinancialSystem : InterfaceGeneric<FinancialSystem>
    {
        Task<IList<FinancialSystem>> ListFinancialSystemUser(string userEmail);
    }
}
