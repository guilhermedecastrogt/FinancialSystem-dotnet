using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.ICategory
{
    public interface ICategory : InterfaceGeneric<Category>
    {
        Task<IList<Category>> ListCategoryUser(string userEmail);
    }
}
