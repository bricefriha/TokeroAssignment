using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data;

public class DcaSetup
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid id { get; set; }
    public DateTime CreatedAt { get; set; }
    public required List<TokenShare> Shares { get; set; }
    public double? Changes { get; set; }
    public double? PriceUsd { get; set; }
}
