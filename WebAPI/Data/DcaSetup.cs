namespace WebAPI.Data;

public class DcaSetup
{
    public DateTime CreatedAt { get; set; }
    public required List<TokenShare> Shares { get; set; }
    public double? Changes { get; set; }
    public double? PriceUsd { get; set; }
}
