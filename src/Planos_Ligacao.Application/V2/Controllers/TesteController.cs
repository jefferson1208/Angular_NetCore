using Microsoft.AspNetCore.Mvc;
using PlanosLigacao.Application.Controllers;
using PlanosLigacao.Domain.Interfaces.Services;

namespace PlanosLigacao.Application.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        public TesteController(INotificador notificador): base(notificador)
        {

        }
        [HttpGet]
        public string Versao1()
        {
            return "Versão 2";
        }
    }
}
