using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Core.Domain.Entities
{
    public class Produtos : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public int Pontos { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
