using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teste.Core.Domain.Entities;
using Teste.WebMvc.Models;
using Teste.WebMvc.Services.Interfaces;

namespace Teste.WebMvc.Controllers
{
    public class CategoriaController : BaseController<Categoria, int, CategoriaModel>
    {
        private readonly IServiceCategoriaMVC _serviceCategoria;
        private readonly IMapper _mapper;
        public CategoriaController(IServiceCategoriaMVC serviceCategoria, IMapper mapper) : base(serviceCategoria, mapper)
        {
            _serviceCategoria = serviceCategoria;
            _mapper = mapper;
        }

        protected override void Listagem()
        {
            //throw new NotImplementedException();
        }
    }
}
