using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos
{
    public class Sapato
    {
        public int Id { get; set; }
        public Modelo Modelo { get; set; }
        public IList<Estoque> Quantidades { get; set; }
        public int Tamanho { get; set; }
    }
}
