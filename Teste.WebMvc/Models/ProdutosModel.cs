using Microsoft.AspNetCore.Mvc;

namespace Teste.WebMvc.Models
{
    public class ProdutosModel 
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Pontos { get; set; }

        public int CategoriaId { get; set; }
    }
}
