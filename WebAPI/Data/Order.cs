using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid id { get; set; }
    public required Token Token { get; set; }
    public double? Price { get; set; }
    public DateTime Date { get; set; }
    public Guid UserDataId { get; set; }
    [ForeignKey(nameof(UserDataId))]
    public UserData? UserData { get; set; } = null;
}
