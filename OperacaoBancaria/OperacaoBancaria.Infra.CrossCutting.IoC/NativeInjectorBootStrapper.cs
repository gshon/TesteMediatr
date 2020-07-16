using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OperacaoBancaria.Domain.ContaCorrente.Commands;
using OperacaoBancaria.Domain.ContaCorrente.Interface;
using OperacaoBancaria.Domain.Core.Notifications;
using OperacaoBancaria.Domain.Handlers;
using OperacaoBancaria.Domain.Interfaces;
using OperacaoBancaria.Domain.Lancamentos.Commands;
using OperacaoBancaria.Domain.Lancamentos.Interface;
using OperacaoBancaria.Infra.Data.Context;
using OperacaoBancaria.Infra.Data.Repository;
using OperacaoBancaria.Infra.Data.UoW;

namespace OperacaoBancaria.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));            

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegistrarContaCorrenteCommand>, ContaCorrenteCommandHandler>();
            services.AddScoped<IRequestHandler<RegistrarLancamentoCommand>, LancamentosCommandHandler>();

            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<ILancamentosRepository, LancamentosRepository>();
        }
    }
}
