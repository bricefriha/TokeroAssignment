using CoinMarketCap;
using CoinMarketCap.Models.Cryptocurrency;
using System.Collections.ObjectModel;
using TokeroAssignment.Models;

namespace TokeroAssignment.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private ObservableCollection<Token> _tokens;
    private CoinMarketCapClient _client;

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
    public HomeViewModel(CoinMarketCapClient client)
    {
        _client = client;
        _tokens = new ObservableCollection<Token>();
    }

    public async Task LoadTokens ()
    {
        Tokens = new ObservableCollection<Token>((await _client.GetLatestListingsAsync(new ListingLatestParameters(), CancellationToken.None))?.Data.Select(l => new Token
        {
            Name = l.Name,
            Symbol = l.Symbol,
            Changes = l.Quote["USD"].PercentChange24H,
            PriceUsd = l.Quote["USD"].Price,


        }).Take(10));
    }
}
