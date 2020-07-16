using MediatR;
using Microsoft.Extensions.Configuration;
using OperacaoBancaria.Domain.ContaCorrente.Interface;
using OperacaoBancaria.Domain.Core.Notifications;
using OperacaoBancaria.Domain.Handlers;
using OperacaoBancaria.Domain.Interfaces;
using OperacaoBancaria.Domain.Lancamentos.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OperacaoBancaria.Domain.Lancamentos.Commands
{
    public class LancamentosCommandHandler : CommandHandler, IRequestHandler<RegistrarLancamentoCommand>
    {
        private readonly ILancamentosRepository _lancamentoRepository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly DomainNotificationHandler _notifications;

        public LancamentosCommandHandler(IUnitOfWork uow, IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications, IConfiguration configuration, ILancamentosRepository lancamentoRepository, IContaCorrenteRepository contaCorrenteRepository) : base(uow, mediator, notifications)
        {
            _lancamentoRepository = lancamentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public Task Handle(RegistrarLancamentoCommand request, CancellationToken cancellationToken)
        {
            var obterContaCorrente = _contaCorrenteRepository.GetEntity(x => x.NumeroConta == request.NumeroConta);

            if(obterContaCorrente == null)
            {
                _notifications.Handle(new DomainNotification("Lancamento", "Conta Corrente Inexistente"), cancellationToken);
                return Task.CompletedTask;
            }                

            var obterUltimoLancamento = _lancamentoRepository.ObterUltimoLancamento(obterContaCorrente.Id);
            var lancamento = new Model.Lancamentos();

            if (obterUltimoLancamento == null)
            {
                lancamento = Model.Lancamentos.LancamentosFactory.NovoLancamentos(request.Valor, request.TipoOperacao, request.Valor, DateTime.Now, obterContaCorrente.Id);
            }
            else
            {
                var saldoAtualizado = request.TipoOperacao == Enum.TipoOperacao.CREDITO ? obterUltimoLancamento.Saldo + request.Valor : obterUltimoLancamento.Saldo - request.Valor;
                lancamento = Model.Lancamentos.LancamentosFactory.NovoLancamentos(request.Valor, request.TipoOperacao, saldoAtualizado, DateTime.Now, obterContaCorrente.Id);
            }            

            if (!lancamento.EhValido())
            {
                NotificarValidacoesErro(lancamento.ValidationResult);
                return Task.CompletedTask;
            }

            _lancamentoRepository.Add(lancamento);

            Commit();

            return Task.CompletedTask;
        }
    }
}
