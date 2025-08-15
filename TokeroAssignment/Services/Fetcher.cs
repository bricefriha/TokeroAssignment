using CustardApi.Objects;
using TokeroAssignment.Models;

namespace TokeroAssignment.Services;

public class Fetcher
{
    private Service _cService;

    public Fetcher()
    {
        _cService = new Service("localhost", port: 5259, sslCertificate: false); 
    }

    /// <summary>
    /// Get Tokens from coin market cap
    /// </summary>
    public async Task<List<Token>> GetTokenFromCmc()
    {
        return await _cService.Get<List<Token>>(controller: "api",
                             action: "tokens");
    }

    /// <summary>
    /// Get the user data
    /// </summary>
    public async Task<User> GetUserDataAsync()
    {
        return await _cService.Get<User>(controller: "api",
                             action: "user");
    }

    /// <summary>
    /// Get dca investments
    /// </summary>
    public async Task<List<Investment>> GetInvestments()
    {
        return await _cService.Get<List<Investment>>(controller: "api",
                             action: "tokens/investments");
    }
}
