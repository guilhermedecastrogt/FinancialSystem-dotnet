using System.ComponentModel.DataAnnotations.Schema;
using Entities._4___Entities.Entities.Enums;

namespace Entities._4___Entities.Entities.Entities;

public class Expenses : Base
{
    public decimal Value { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public ExpensesTypeEnum ExpenseType { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool Paid { get; set; }
    public bool DelayedExpense { get; set; }
    
    [ForeignKey("Category")]
    [Column(Order = 1)]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}