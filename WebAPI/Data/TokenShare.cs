using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data;

public class TokenShare
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid id { get; set; }
    /// <summary>
    /// Date of the first setup, each iteration will be based monthly from this date
    /// </summary>
    public DateTime DateSetup { get; set; }
    public double? Pourcentage { get; set; }
    /// <summary>
    /// Fix amount in USD, if not null, overwrite the Pourcentage property
    /// </summary>
    public double? FixAmountUSD { get; set; }
    public required Token Token { get; set; }
}
