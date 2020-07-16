using MediatR;
using Microsoft.Extensions.Configuration;
using OperacaoBancaria.Domain.ContaCorrente.Interface;
using OperacaoBancaria.Domain.Core.Notifications;
using OperacaoBancaria.Domain.Handlers;
using OperacaoBancaria.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OperacaoBancaria.Domain.ContaCorrente.Commands
{
    public class ContaCorrenteCommandHandler : CommandHandler, IRequestHandler<RegistrarContaCorrenteCommand>
    {
        private readonly IMediatorHandler _mediator;
        private readonly IConfiguration _configuration;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly DomainNotificationHandler _notifications;

        public ContaCorrenteCommandHandler(IUnitOfWork uow,
                                                        INotificationHandler<DomainNotification> notifications,
                                                        IMediatorHandler mediator,
                                                        IConfiguration configuration,
                                                        IContaCorrenteRepository contaCorrenteRepository) : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _configuration = configuration;
            _contaCorrenteRepository = contaCorrenteRepository;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public Task Handle(RegistrarContaCorrenteCommand request, CancellationToken cancellationToken)
        {
            var contaCorrente = Model.ContaCorrente.ContaCorrenteFactory.NovoConta(request.Nome, request.Cpf, request.NumeroConta);

            if (!contaCorrente.EhValido())
            {
                NotificarValidacoesErro(contaCorrente.ValidationResult);
                return Task.CompletedTask;
            }

            _contaCorrenteRepository.Add(contaCorrente);

            Commit();

            return Task.CompletedTask;
        }
    }
}
