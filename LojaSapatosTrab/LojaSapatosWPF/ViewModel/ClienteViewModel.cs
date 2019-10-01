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
            this.Clientes = new ObservableCollection<Pessoa>(this.Context.Pessoas.Include("Endereco").ToList());

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

        public void AdicionarPessoaFisica()
        {
            this.Context.SaveChanges();
            ClienteSelecionado = null;
            Pessoa pFisica = new PessoaFisica();
            this.Clientes.Add(pFisica);
            ClienteSelecionado = pFisica;
        }

        public void Remover()
        {
            var pessoaDelecao = this.Context.Pessoas.Find(ClienteSelecionado.Id);

            this.Context.Pessoas.Remove(pessoaDelecao);

            this.Salvar();

            this.Clientes = new ObservableCollection<Pessoa>(this.Context.Pessoas.Include("Endereco").ToList());

            ClienteSelecionado = this.Clientes.FirstOrDefault();
        }
    }
}
