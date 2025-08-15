using System.Collections.ObjectModel;

namespace TokeroAssignment.Models;

public class DcaSetup
{
    public string UserDataId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public double? AllocationAmountUSD { get; set; }

    private int? _dayOfMonth;
    public int DayOfMonth { get => _dayOfMonth?? CreatedAt.Day; set 
        {
            // Don't allow 0 as value
            if (value == 0)
            {
                _dayOfMonth = CreatedAt.Day;
                return;
            }

            _dayOfMonth = value;
        } }
    public required ObservableCollection<TokenShare> Shares { get; set; }
}
