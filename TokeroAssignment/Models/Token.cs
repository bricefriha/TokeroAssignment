namespace TokeroAssignment.Models;

public class Token
{
    public string Name { get; set; }
    public string Symbol { get; set; }
    public double? Changes { get; set; }
    public double? PriceUsd { get; set; }
}
