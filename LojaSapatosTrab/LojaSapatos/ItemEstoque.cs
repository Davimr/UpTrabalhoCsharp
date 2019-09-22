using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos
{
    public class ItemEstoque
    {
        public int Id { get; set; }
        
        public int Quantidade { get; set; }

        public Sapato Sapato { get; set; }
    }
}
