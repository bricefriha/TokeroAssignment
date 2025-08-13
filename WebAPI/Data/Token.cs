namespace WebAPI.Data;

public class Token
{
    public required string Name { get; set; }
    public int CmcId { get; set; }
    public required string Symbol { get; set; }
    public double? Changes { get; set; }
    public double? PriceUsd { get; set; }
}
