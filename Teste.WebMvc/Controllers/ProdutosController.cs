using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public ProdutosController(IServiceProdutosMVC serviceProdutos, IMapper mapper, IServiceCategoriaMVC serviceCategorias) : base(serviceProdutos, mapper)
        {
            _serviceProdutos = serviceProdutos;
            _mapper = mapper;
            _serviceCategorias = serviceCategorias; 
        }

        protected override void Listagem()
        {
            //throw new NotImplementedException();

        }

        protected override void ViewBagCreate()
        {
            //throw new NotImplementedException();

        }

        public async Task<IActionResult> Remove(int id)
        {
            Produtos dados = await _serviceProdutos.GetByIdAsync(id);

            if (dados != null) return View(_mapper.Map<ProdutosModel>(dados));
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(ProdutosModel model)
        {
            var response = await _serviceProdutos.DeleteAsync(model.Id);
            if (response) return RedirectToAction(nameof(List));
            return View(model);
        }

        protected override void ViewBagEdit()
        {
           // throw new NotImplementedException();
        }
    }
}
