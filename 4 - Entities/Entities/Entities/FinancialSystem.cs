using System.ComponentModel.DataAnnotations.Schema;

namespace Entities._4___Entities.Entities.Entities;

[Table("FINANCIAL_SYSTEM")]
public class FinancialSystem : Base
{
    public int Month { get; set; }
    public int Year { get; set; }
    public int ClosingDay { get; set; }
    public bool ExpenseCopyGenerator { get; set; }
    public int CopyMonth { get; set; }
    public int CopyYear { get; set; }
}