using System.ComponentModel.DataAnnotations.Schema;

namespace TokeroAssignment.Models;

public class Balance
{
    public double? AmountUSD { get; set; }
    public double AmountToken { get; set; } = 0;
    public Guid UserDataId { get; set; }
    public Guid TokenId { get; set; }
    public required Token Token { get; set; }
}