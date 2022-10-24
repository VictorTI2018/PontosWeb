using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Core.Domain.Dtos;
using Teste.Core.Domain.Entities;
using Teste.Core.Domain.Interfaces.Services;

namespace Teste.Application.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProdutosController : BaseAsyncController<Produtos, int, ProdutosDto>
    {
        private readonly IServiceProdutos _serviceProduts;
        private readonly IMapper _mapper;

        public ProdutosController(IServiceProdutos serviceProduts, IMapper mapper) : base(serviceProduts, mapper)
        {
            _serviceProduts = serviceProduts;
            _mapper = mapper;
        }

        [HttpGet("{categoriaId}")]
        public async Task<IActionResult> GetProdutosPorCategoria(int categoriaId)
        {
            return Ok(await _serviceProduts.GetProdutosPorCategoria(categoriaId));
        }
    }
}
