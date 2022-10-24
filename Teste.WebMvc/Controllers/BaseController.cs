using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teste.WebMvc.Services.Interfaces;
using X.PagedList;

namespace Teste.WebMvc.Controllers
{
    public abstract class BaseController<TEntity, TKey, TModel> : Controller where TEntity : class
    {
        private readonly IServiceBaseMVC<TEntity, TKey> _serviceBase;

        private readonly IMapper _mapper;

        private const int QuantidadeDeLinhas = 4;

        public BaseController(IServiceBaseMVC<TEntity, TKey> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }

        protected abstract void Listagem();

        public async Task<IActionResult> List(int? page)
        {
            var lista = await _serviceBase.GetAsync();
            IEnumerable<TModel> listTmodel = _mapper.Map<IEnumerable<TModel>>(lista);

            int pageNumber = (page ?? 1);

            Listagem();
            var teste = listTmodel.ToPagedList(pageNumber, QuantidadeDeLinhas);
            return View(teste);
        }

        protected abstract void ViewBagCreate();

        public async Task<IActionResult> Create()
        {
            ViewBagCreate();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TModel model)
        {
            var response = await _serviceBase.SaveAsync(_mapper.Map<TEntity>(model));
            if (response != null) return RedirectToAction(nameof(List));
            return View(model);
        }

        protected abstract void ViewBagEdit();
        public async Task<IActionResult> Edit(TKey id)
        {
            TEntity dados = await _serviceBase.GetByIdAsync(id);

            ViewData["id"] = id;

            ViewBagEdit();

            if (dados != null) return View(_mapper.Map<TModel>(dados));
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TModel model)
        {
            var response = await _serviceBase.UpdateAsync(_mapper.Map<TEntity>(model));
            if (response != null) return RedirectToAction(nameof(List));
            return View(model);
        }
        
    }
}
