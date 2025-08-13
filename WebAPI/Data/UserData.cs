namespace WebAPI.Data;

public class UserData
{

    public List<DcaSetup>? Shares { get; set; }
    public List<Balance>? Balances { get; set; }
    public List<Order>? Orders { get; set; }
    public double? Changes { get; set; }
    public double? PriceUsd { get; set; }
}
