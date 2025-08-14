using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data;

public class Balance
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid id { get; set; }

    [NotMapped]
    public double? AmountUSD { get; set; }
    public double? AmountToken { get; set; }
    public Guid UserDataId { get; set; }
    [ForeignKey(nameof(UserDataId))]
    public required UserData UserData { get; set; }
    public Guid TokenId { get; set; }
    [ForeignKey(nameof(TokenId))]
    public required Token Token { get; set; }

}
