namespace WebAPI.Data;

public class Balance
{
    public required Token Token { get; set; }
    public double? AmountUSD { get; set; }
    public double? AmountToken { get; set; }

}
