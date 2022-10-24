using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Core.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public IEnumerable<Produtos> Produtos { get; set; }
    }
}
