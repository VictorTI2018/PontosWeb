using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teste.WebMvc.Services.Interfaces;
using X.PagedList;

namespace Teste.WebMvc.Controllers
{
    public abstract class BaseController<TEntity, TKey,TModel> : Controller where TEntity : class
    {
        private readonly IServiceBaseMVC<TEntity, TKey> _serviceBase;

        private readonly IMapper _mapper;

        private const int QuantidadeDeLinhas = 1;

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
    }
}
