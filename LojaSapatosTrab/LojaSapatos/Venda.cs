using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        [InverseProperty("Venda")]
        public IList<ItemPedido> ItensPedido { get; set; }
        public Decimal ValorTotal { get; set; }
        public int QuantidadeTotal { get; set; }
        public Pessoa Cliente { get; set; }
    }
}
