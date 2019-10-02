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
        public ObservableCollection<Sapato> Sapatos { get; set; }
        public ClienteViewModel Cliente { get; set; }
        private SapatoModel ContextVenda { get; set; }
        public VendaViewModel()
        {
            
            this.Cliente = new ClienteViewModel();
            this.ContextVenda = new SapatoModel();
            this.Vendas = new ObservableCollection<Venda>(this.ContextVenda.Vendas.Include("Cliente").ToList());
            this.Sapatos = new ObservableCollection<Sapato>(this.ContextVenda.Sapatos.Include("Modelo").Include("ItemEstoque").ToList());

            VendaSelecionada = this.ContextVenda.Vendas.Include("Cliente").ToList().FirstOrDefault();
        }

        public void Salvar()
        {
            this.ContextVenda.SaveChanges();
        }

        public void Adicionar()
        {
            Venda venda = new LojaSapatos.Venda();
            Pessoa pessoa = new LojaSapatos.Pessoa();
            venda.Cliente = pessoa;
            this.Vendas.Add(venda);
            VendaSelecionada = venda;
            this.ContextVenda.Vendas.Add(venda);

        }

        public void Remover()
        {
            var vendaDeletada = this.ContextVenda.Vendas.Find(VendaSelecionada.Id);
            this.ContextVenda.Vendas.Remove(vendaDeletada);
            this.Salvar();
            this.Vendas = new ObservableCollection<Venda>(this.ContextVenda.Vendas.Include("Cliente").ToList());
            VendaSelecionada = this.Vendas.FirstOrDefault();
        }
    }
}
