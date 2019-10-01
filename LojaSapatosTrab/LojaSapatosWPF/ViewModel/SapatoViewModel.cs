using LojaSapatos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatosWPF.ViewModel
{
    public class SapatoViewModel
    {
        public ObservableCollection<Sapato> Sapatos { get; set; }
        public Sapato SapatoSelecionado { get; set; }
        public ObservableCollection<Modelo> Modelos { get; set; }

        private SapatoModel ContextSapato { get; set; }
        public SapatoViewModel()
        {
            this.ContextSapato = new SapatoModel();
            this.Sapatos = new ObservableCollection<Sapato>(this.ContextSapato.Sapatos.Include("Modelo").Include("ItemEstoque").ToList());
            this.Modelos = new ObservableCollection<Modelo>(this.ContextSapato.Modelos.ToList());
            this.SapatoSelecionado = this.ContextSapato.Sapatos.Include("Modelo").Include("ItemEstoque").ToList().FirstOrDefault();
        }

        public void Salvar()
        {
            this.ContextSapato.SaveChanges();
        }

        public void Adicionar()
        {
            Sapato sapato = new LojaSapatos.Sapato();
            ItemEstoque itemEstoque = new LojaSapatos.ItemEstoque();
            sapato.ItemEstoque = itemEstoque;
            this.Sapatos.Add(sapato);
            this.ContextSapato.Sapatos.Add(sapato);
            this.SapatoSelecionado = sapato;

        }

        public void Remover()
        {
            var sapatoDelete = this.ContextSapato.Sapatos.Find(SapatoSelecionado.Id);
            this.ContextSapato.Sapatos.Remove(sapatoDelete);
            this.Salvar();
            this.Sapatos = new ObservableCollection<Sapato>(this.ContextSapato.Sapatos.Include("Modelo").ToList());
            this.SapatoSelecionado = this.Sapatos.FirstOrDefault();
        }
    }
}
