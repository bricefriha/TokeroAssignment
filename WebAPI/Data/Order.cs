namespace WebAPI.Data;

public class Order
{
    public required Token Token { get; set; }
    public double? Price { get; set; }
    public DateTime Date { get; set; }
}
