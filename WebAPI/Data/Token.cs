using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data;

public class Token
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid id { get; set; }
    /// <summary>
    /// Id on CoinMarketCap ; used to interact with the CoinMarketCap API
    /// </summary>
    public int CmcId { get; set; }
    public required string Name { get; set; }
    public required string Symbol { get; set; }

    [NotMapped]
    public double? Changes { get; set; }

    [NotMapped]
    public double? PriceUsd { get; set; }
}
