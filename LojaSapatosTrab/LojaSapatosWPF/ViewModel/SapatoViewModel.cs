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
            this.Sapatos = new ObservableCollection<Sapato>(this.ContextSapato.Sapatos.ToList());

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
            this.ContextSapato.Sapatos.Remove(SapatoSelecionado);
            this.Sapatos.Remove(SapatoSelecionado);
            SapatoSelecionado = this.Sapatos.FirstOrDefault();
        }
    }
}
