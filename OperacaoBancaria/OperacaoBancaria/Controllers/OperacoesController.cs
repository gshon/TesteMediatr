using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperacaoBancaria.Application.ViewModels;
using OperacaoBancaria.Application.ViewModels.Lancamentos;
using OperacaoBancaria.Domain.ContaCorrente.Commands;
using OperacaoBancaria.Domain.Core.Notifications;
using OperacaoBancaria.Domain.Interfaces;
using OperacaoBancaria.Domain.Lancamentos.Commands;

namespace OperacaoBancaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperacoesController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public OperacoesController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IMapper mapper) : base(notifications, mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        [HttpPost]
        [Route("CadastraCliente")]
        public IActionResult Post([FromBody] RegistrarContaCorrenteViewModel model)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var contaCorrenteCommand = _mapper.Map<RegistrarContaCorrenteCommand>(model);

            _mediator.EnviarComando(contaCorrenteCommand);

            if (_notifications.HasNotifications())
                return Response(_notifications.GetNotifications());

            return Response();
        }

        [HttpPost]
        [Route("Lancamento")]
        public IActionResult Post([FromBody] RegistrarLancamentosViewModel model)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var lancamentoCommand = _mapper.Map<RegistrarLancamentoCommand>(model);

            _mediator.EnviarComando(lancamentoCommand);

            if (_notifications.HasNotifications())
                return Response(_notifications.GetNotifications());

            return Response();
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }
    }
}
