namespace TokeroAssignment.Models;

public class User
{
    public string Username { get; set; }
    public List<DcaSetup>? Shares { get; set; }
    public List<Balance>? Balances { get; set; }
    public List<Order>? Orders { get; set; }
}
