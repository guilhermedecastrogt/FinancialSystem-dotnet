using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{

    [Table("FinancialSystemUser")]
    public class FinancialSystemUser
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }
        public bool CurrentSystem { get; set; }


        [ForeignKey("FinancialSystem")]
        [Column(Order = 1)]
        public int IdSystem { get; set; }
        public virtual FinancialSystem FinancialSystem { get; set; }
    }
}
