using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TokeroAssignment.Models;

public class TokenShare
{
    public DateTime DateSetup { get; set; } = DateTime.UtcNow;
    public double? Pourcentage { get; set; } = 0;
    /// <summary>
    /// Fix amount in USD, if not null, overwrite the Pourcentage property
    /// </summary>
    public double? FixAmountUSD { get; set; }
    public Guid TokenId { get; set; }
    public Token Token { get; set; }
    [JsonIgnore]
    public bool IsFixedAmount { get; set; }
}
