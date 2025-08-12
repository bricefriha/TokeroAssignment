using System.Collections.ObjectModel;
using TokeroAssignment.Models;

namespace TokeroAssignment.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private ObservableCollection<Token> _tokens;
    public ObservableCollection<Token> Tokens
    {
        get 
        { 
            return _tokens; 
        }
        set
        {
            _tokens = value;
            OnPropertyChanged(nameof(Tokens));
        }
    }
    public HomeViewModel()
    {
        _tokens = new ObservableCollection<Token>()
        {
            new ()
            {
                Name = "Cardano",
                Symbol= "ADA",
            },
            new ()
            {
                Name = "Cardano",
                Symbol= "ADA",
            }
        };
    }
}
