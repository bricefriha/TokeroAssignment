namespace WebAPI.Data;

/// <summary>
/// DCA investment are calculated based on the orders we have
/// </summary>
public class DcaInvestment
{
    public DateTime DateStart { get; set; }
    public required Token Token { get; set; }
    public double AmountUSD { get; set; }
    public double AmountToken { get; set; }
    public double CurrentValue { get; set; }
    public double PourcentageChange { get; set; }
}
