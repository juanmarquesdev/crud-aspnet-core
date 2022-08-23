using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Models
{
    public class Produtos
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage ="Campo descrição obrigatório")]
        public string Descricao {get; set;}

        [Required(ErrorMessage ="Campo preço obrigatório")]
        public float? Preco {get; set;}

    }
}