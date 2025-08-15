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

    public Task<List<Token>> GetTokenFromCmc()
    {
        return _cService.Get<List<Token>>(controller: "api",
                             action: "tokens");
    }


}
