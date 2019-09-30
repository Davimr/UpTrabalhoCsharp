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
        private SapatoModel ContextSapato { get; set; }
        public SapatoViewModel()
        {
            this.ContextSapato = new SapatoModel();
            this.Sapatos = new ObservableCollection<Sapato>(this.ContextSapato.Sapatos.Include("Modelo").ToList());

            SapatoSelecionado = this.Sapatos.FirstOrDefault();
        }

        public void Salvar()
        {
            this.ContextSapato.SaveChanges();
        }

        public void Adicionar()
        {
            Sapato sapato = new LojaSapatos.Sapato();
            this.Sapatos.Add(sapato);
            SapatoSelecionado = sapato;

        }

        public void Remover()
        {
            var sapatoDelete = this.ContextSapato.Sapatos.Find(SapatoSelecionado.Id);
            this.ContextSapato.Sapatos.Remove(sapatoDelete);
            this.Salvar();
            this.Sapatos = new ObservableCollection<Sapato>(this.ContextSapato.Sapatos.Include("Modelo").ToList());
            SapatoSelecionado = this.Sapatos.FirstOrDefault();
        }
    }
}
