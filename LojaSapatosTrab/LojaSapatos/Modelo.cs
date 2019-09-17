using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos
{
    public class Modelo
    {
        public int Id { get; set; }
        public Sapato Nome { get; set; }
        public Boolean PossuiCadarco { get; set; }
        public String Material { get; set; }
        public String Cor { get; set; }
        public Decimal Preco { get; set; }
        public String Fotografia { get; set; }


    }
}
