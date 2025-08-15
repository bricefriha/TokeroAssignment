using System.Collections.ObjectModel;

namespace TokeroAssignment.Models;

public class DcaSetup
{
    public string UserDataId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required ObservableCollection<TokenShare> Shares { get; set; }
}
