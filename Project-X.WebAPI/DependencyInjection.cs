using Microsoft.AspNetCore.Authentication;
using Project_X.Interface.Repositories;
using Project_X.Interface.Services;
using Project_X.Repository.Repositories;
using Project_X.Sevice.Services;
using MediatR;
using Project_X.Domain.Entities.Shared;
using Project_X.Interface.Domain;
using Project_X.Domain.Notifications;
using Project_X.Repository.Repositorios;

namespace Project_X.WebAPI
{
    public class DependencyInjection
    {
        public static IConfiguration Configuration { get; }
       // public static DbConnection DbConnection => new NpgsqlConnection(Configuration.GetConnectionString("App"));


        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddMediatR(typeof(ApiNotifications).Assembly);
            serviceProvider.AddScoped<INotificationsService, NotificationsService>();

            serviceProvider.AddScoped<IAutenticacaoServico, AutenticacaoServico>();
            serviceProvider.AddScoped<IAutenticacaoRepositorio, AutenticacaoRepositorio>();

            serviceProvider.AddScoped<ITokenService, TokenService>();
            serviceProvider.AddScoped<IPasswordService, PasswordService>();

            serviceProvider.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            serviceProvider.AddScoped<IEnderecoServico, EnderecoServico>();

            serviceProvider.AddScoped<IPessoaServico, PessoaServico>();
            serviceProvider.AddScoped<IPessoaRepositorio, PessoaRepositorio>();

            serviceProvider.AddScoped<IFisioterapeutaServico, FisioterapeutaServico>();
            serviceProvider.AddScoped<IFisioterapeutaRepositorio, FisioterapeutaRepositorio>();

            serviceProvider.AddScoped<IPacienteServico, PacienteServico>();
            serviceProvider.AddScoped<IPacienteRepositorio, PacienteRepositorio>();

            serviceProvider.AddScoped<IConsultaServico, ConsultaServico>();
            serviceProvider.AddScoped<IConsultaRepositorio, ConsultaRepositorio>();

            serviceProvider.AddScoped<IFisioterapiaServico, FisioterapiaServico>();
            serviceProvider.AddScoped<IFisioterapiaRepositorio, FisioterapiaRepositorio>();

            serviceProvider.AddMemoryCache();

        }
    }
}

