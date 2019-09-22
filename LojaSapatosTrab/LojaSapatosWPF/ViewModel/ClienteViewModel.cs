using LojaSapatos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatosWPF.ViewModel
{
    public class ClienteViewModel
    {
        public ObservableCollection<Pessoa> Clientes { get; set; }
        public Pessoa ClienteSelecionado { get; set; }
        private SapatoModel Context { get; set; }
        public ClienteViewModel()
        {
            this.Context = new SapatoModel();
            this.Clientes = new ObservableCollection<Pessoa>(
                this.Context.Pessoas.ToList());

            ClienteSelecionado = this.Clientes.FirstOrDefault();
        }

        public void Salvar()
        {
            this.Context.SaveChanges();
        }

        public void Adicionar()
        {
            Pessoa p = new Pessoa();
            this.Clientes.Add(p);
            ClienteSelecionado = p;
        }

        public void Remover()
        {
            this.Context.Pessoas.Remove(ClienteSelecionado);
            this.Clientes.Remove(ClienteSelecionado);
            ClienteSelecionado = this.Clientes.FirstOrDefault();
        }
    }
}
