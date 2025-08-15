namespace TokeroAssignment.Models;

public class Investment
{
    public DateTime DateStart { get; set; }
    public required Token Token { get; set; }
    public double AmountUSD { get; set; }
    public double AmountToken { get; set; }
    public double CurrentValue { get; set; }
    public double PourcentageChange { get; set; }
}
