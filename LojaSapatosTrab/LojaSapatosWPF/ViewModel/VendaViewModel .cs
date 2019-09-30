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

        public ClienteViewModel Cliente { get; set; }
        private SapatoModel ContextVenda { get; set; }
        public VendaViewModel()
        {
            
            this.Cliente = new ClienteViewModel();
            this.ContextVenda = new SapatoModel();
            this.Vendas = new ObservableCollection<Venda>(this.ContextVenda.Vendas.Include("ItemPedido").ToList());

           
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
