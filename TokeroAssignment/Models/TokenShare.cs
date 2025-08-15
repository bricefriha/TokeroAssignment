using System.ComponentModel.DataAnnotations.Schema;

namespace TokeroAssignment.Models;

public class TokenShare
{
    public DateTime DateSetup { get; set; } = DateTime.UtcNow;
    public double? Pourcentage { get; set; }
    /// <summary>
    /// Fix amount in USD, if not null, overwrite the Pourcentage property
    /// </summary>
    public double? FixAmountUSD { get; set; }
    public Guid TokenId { get; set; }
    public required Token Token { get; set; }
}
