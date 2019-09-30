using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos
{
    public class Modelo
    {
        public int Id { get; set; }
        public Boolean PossuiCadarco { get; set; }
        public String Material { get; set; }
        public String Cor { get; set; }
        public Decimal Preco { get; set; }
        public String Fotografia { get; set; }
        public String Nome { get; set; }



    }
}
