using LojaSapatos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatosWPF.ViewModel
{
    public class VendaViewModel
    {
        public ObservableCollection<Venda> Vendas { get; set; }
        public Venda VendaSelecionada { get; set; }
        private SapatoModel ContextVenda { get; set; }
        public VendaViewModel()
        {
            Venda venda1 = new LojaSapatos.Venda()
            {
                DataVenda = new DateTime(2019, 09, 23),
                QuantidadeTotal = 3,
                ValorTotal = 234.90M,
            };            

            this.ContextVenda = new SapatoModel();
            this.Vendas = new ObservableCollection<Venda>(this.ContextVenda.Vendas.ToList());

            Vendas.Add(venda1);

            VendaSelecionada = this.Vendas.FirstOrDefault();
        }

        public void Salvar()
        {
            this.ContextVenda.SaveChanges();
        }

        public void Adicionar()
        {
            Venda venda = new LojaSapatos.Venda();
            this.Vendas.Add(venda);
            VendaSelecionada = venda;


        }

        public void Remover()
        {
            this.ContextVenda.Vendas.Remove(VendaSelecionada);
            this.Vendas.Remove(VendaSelecionada);
            VendaSelecionada = this.Vendas.FirstOrDefault();
        }
    }
}
