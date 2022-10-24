using AutoMapper;
using Teste.Core.Domain.Entities;
using Teste.WebMvc.Models;

namespace Teste.WebMvc.Utils
{
    public class MapperDtoProfile: Profile
    {
        public MapperDtoProfile()
        {
            CreateMap<CategoriaModel, Categoria>();
            CreateMap<Categoria, CategoriaModel>();

            CreateMap<ProdutosModel, Produtos>();
            CreateMap<Produtos, ProdutosModel>();
        }
    }
}
