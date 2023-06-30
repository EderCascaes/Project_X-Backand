using MediatR;
using Microsoft.Extensions.Configuration;


namespace Project_X.Interface.Domain
{
    public  interface IApiHttpService
    {
        IConfiguration IConfiguration { get; }
        IMediator IMediator { get; }

        //Task<string> ObterToken(string idDaUnidade, string idDaRede, string idDoParceiro);
    }
}
