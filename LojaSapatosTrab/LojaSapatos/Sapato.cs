using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos
{
    public class Sapato
    {
        public int Id { get; set; }
        public Modelo Modelo { get; set; }

        public ItemEstoque Quantidade { get; set; }
        public int Tamanho { get; set; }

        [InverseProperty("Sapato")]
        public IList<ItemPedido> ItensPedido { get; set; }

    }
}
