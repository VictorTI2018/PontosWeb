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

        protected override void ViewBagCreate()
        {
            //throw new NotImplementedException();
        }

        protected override void ViewBagEdit()
        {
           // throw new NotImplementedException();
        }

        public async Task<IActionResult> Remove(int id)
        {
            Categoria dados = await _serviceCategoria.GetByIdAsync(id);

            if (dados != null) return View(_mapper.Map<CategoriaModel>(dados));
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(CategoriaModel model)
        {
            var response = await _serviceCategoria.DeleteAsync(model.Id);
            if (response) return RedirectToAction(nameof(List));
            return View(model);
        }
    }
}
