using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data;

public class Balance
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid id { get; set; }
    public required Token Token { get; set; }
    public double? AmountUSD { get; set; }
    public double? AmountToken { get; set; }

}
