using System.Collections.ObjectModel;

namespace TokeroAssignment.Models;

public class DcaSetup
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required ObservableCollection<TokenShare> Shares { get; set; }
    public double? Changes { get; set; }
    public double? PriceUsd { get; set; }
}
