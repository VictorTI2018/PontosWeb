using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Core.Domain.Dtos;
using Teste.Core.Domain.Entities;

namespace Teste.Infra.Shared.MapperDto
{
    public class MapperDtoProfile: Profile
    {
        public MapperDtoProfile()
        {
            CreateMap<CategoriaDto, Categoria>();
            CreateMap<Categoria, CategoriaDto>();

            CreateMap<ProdutosDto, Produtos>();
            CreateMap<Produtos, ProdutosDto>();
        }
    }
}
