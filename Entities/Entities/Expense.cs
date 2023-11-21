using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{

    [Table("Expense")]
    public  class Expense : Base
    {

        public decimal Value { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public ExpenseTypeEnum ExpenseType { get; set; }

        public DateTime RegisterAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime PaymentAt { get; set; }

        public DateTime DueDate { get; set; }

        public bool PaydOut { get; set; }

        public bool LatePayment { get; set; }

        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int IdCategory { get; set; }
        public virtual Category Category { get; set; }
    }
}
