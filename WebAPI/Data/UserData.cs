using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data;

public class UserData
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid id { get; set; }
    public string Username { get; set; }
    public List<DcaSetup>? Shares { get; set; }
    public List<Balance>? Balances { get; set; }
    public List<Order>? Orders { get; set; }
}
