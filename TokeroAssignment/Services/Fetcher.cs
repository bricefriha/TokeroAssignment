using CustardApi.Objects;
using TokeroAssignment.Models;

namespace TokeroAssignment.Services;

public class Fetcher
{
    private Service _cService;

    public Fetcher(FetcherOptionBuilder options)
    {
        _cService = new Service(options.Host, 
                                port: options.Port, 
                                sslCertificate: options.SslCertificate); 
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
    public async Task<List<Investment>> GetInvestmentsAsync()
    {
        return await _cService.Get<List<Investment>>(controller: "api",
                             action: "tokens/investments");
    }

    /// <summary>
    /// Get dca setups
    /// </summary>
    public async Task<List<DcaSetup>> GetDcaSetupAsync()
    {
        return await _cService.Get<List<DcaSetup>>(controller: "api",
                             action: "setup");
    }

    /// <summary>
    /// Create a setup
    /// </summary>
    public async Task<List<DcaSetup>> InsertDcaSetupAsync(DcaSetup setup)
    {
        return await _cService.Post<List<DcaSetup>>(controller: "api",
                             action: "setup",
                             payload: setup
                             );
    }
}
