using System.ComponentModel.DataAnnotations.Schema;

namespace Entities._4___Entities.Entities.Entities;

[Table("FINANCIAL_SYSTEM_USER")]
public class FinancialSystemUser
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public bool IsAdmin { get; set; }
    public bool SetSystem { get; set; }
    
    [ForeignKey("FinancialSystem")]
    [Column(Order = 1)]
    public int SystemId { get; set; }

    public virtual FinancialSystem FinancialSystem { get; set; }
}