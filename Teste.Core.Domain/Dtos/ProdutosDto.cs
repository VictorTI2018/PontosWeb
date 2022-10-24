using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Core.Domain.Dtos
{
    public class ProdutosDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Pontos { get; set; }

        public int CategoriaId { get; set; }
    }
}
