﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Domain.Interfaces.IServices
{
    public interface IExpenseService
    {
        Task AddExpense(Expense expense);
        Task UpdateExpense(Expense expense);
    }
}
