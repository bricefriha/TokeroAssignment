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
    /// Get Tokens from coin market caps 
    /// </summary>

    public async Task<List<Token>> GetTokenFromCmc()
    {
        return await _cService.Get<List<Token>>(controller: "api",
                             action: "tokens");
    }


}
