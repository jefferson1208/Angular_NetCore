using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanosLigacao.Application.Controllers;
using PlanosLigacao.Application.ViewModels.Planos;
using PlanosLigacao.Domain.Entities.Planos;
using PlanosLigacao.Domain.Interfaces.Services;

namespace PlanosLigacao.Application.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/planos")]
    public class PlanoController : MainController
    {
        private readonly ICustoPlanoService _custoPlanoService;
        private readonly IPlanoService _planoService;
        private readonly IMapper _mapper;
        public PlanoController(ICustoPlanoService custoPlanoService, IPlanoService planoService, 
            IMapper mapper, INotificador notificador): base(notificador)
        {
            _custoPlanoService = custoPlanoService;
            _planoService = planoService;
            _mapper = mapper;
        }

        [HttpGet("planos-disponiveis")]
        public async Task<IEnumerable<PlanoViewModel>> PlanosDisponiveis()
        {
            var planos = _mapper.Map<IEnumerable<PlanoViewModel>>(
                await _planoService.GetAll());

            return planos;
        }

        [HttpGet("custo-planos")]
        public async Task<IEnumerable<CustoPlanoViewModel>> CustoPlanos()
        {
            var custos = _mapper.Map<IEnumerable<CustoPlanoViewModel>>(
                await _custoPlanoService.GetAll());

            return custos;
        }

        [HttpPost("calcular-custo-plano")]
        public async Task<ActionResult> CalcularCustoPlano(CalculoPlanoViewModel calculoPlano)
        {
            var custoPlano = await _custoPlanoService.CalcularCustoPlano(_mapper.Map<CalculoPlano>(calculoPlano));

            return CustomResponse(custoPlano);
        }
    }
}
