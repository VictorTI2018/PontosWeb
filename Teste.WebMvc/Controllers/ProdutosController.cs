using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teste.Core.Domain.Entities;
using Teste.WebMvc.Models;
using Teste.WebMvc.Services.Interfaces;
namespace Teste.WebMvc.Controllers
{
    public class ProdutosController : BaseController<Produtos, int, ProdutosModel>
    {
        private readonly IServiceProdutosMVC _serviceProdutos;
        private readonly IServiceCategoriaMVC _serviceCategorias;
        private readonly IMapper _mapper;

        public ProdutosController(IServiceProdutosMVC serviceProdutos, IMapper mapper,
            IServiceCategoriaMVC serviceCategoriaMVC) : base(serviceProdutos, mapper)
        {
            _serviceProdutos = serviceProdutos;
            _mapper = mapper;
            _serviceCategorias = serviceCategoriaMVC;
        }

        protected async override void Listagem()
        {
            //throw new NotImplementedException();

            ViewBag.Categorias = await _serviceCategorias.GetAsync();
        }


    }
}
