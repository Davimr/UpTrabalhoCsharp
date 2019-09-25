using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSapatos
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        [InverseProperty("Cliente")]
        public IList<Venda> Vendas { get; set; }
    }
}