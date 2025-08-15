using System.ComponentModel.DataAnnotations.Schema;

namespace TokeroAssignment.Models;

public class Order
{
    public required Token Token { get; set; }
    public double Price { get; set; }
    public double AmountToken { get; set; }
    public DateTime Date { get; set; }
}