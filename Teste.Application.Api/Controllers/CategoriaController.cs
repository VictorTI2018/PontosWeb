using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Core.Domain.Dtos;
using Teste.Core.Domain.Entities;
using Teste.Core.Domain.Interfaces.Services;

namespace Teste.Application.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : BaseAsyncController<Categoria, int, CategoriaDto>
    {
        private readonly IServiceCategoria _serviceCategoria;
        private readonly IMapper _mapper;

        public CategoriaController(IServiceCategoria serviceCategoria, IMapper mapper): base(serviceCategoria, mapper)
        {
            _serviceCategoria = serviceCategoria;
            _mapper = mapper;
        }
    }
}
