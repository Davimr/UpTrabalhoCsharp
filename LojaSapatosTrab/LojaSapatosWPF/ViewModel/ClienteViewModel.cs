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
            this.Clientes = new ObservableCollection<Pessoa>(this.Context.Pessoas.Include("Endereco").Include("Vendas").ToList());

            ClienteSelecionado = this.Context.Pessoas.Include("Endereco").ToList().FirstOrDefault();
        }

        public void Salvar()
        {
            this.Context.SaveChanges();
        }

        public void AdicionarPessoaFisica()
        {
            ClienteSelecionado = null;
            Pessoa pFisica = new PessoaFisica();
            pFisica.Nome = "NovoFisica";
            this.Clientes.Add(pFisica);
            ClienteSelecionado = pFisica;
            this.Context.Pessoas.Add(pFisica);
            this.Context.SaveChanges();
        }

        public void AdicionarPessoaJuridica()
        {
            ClienteSelecionado = null;
            Pessoa pJuridica = new PessoaJuridica();
            pJuridica.Nome = "NovoJuridico";
            this.Clientes.Add(pJuridica);
            ClienteSelecionado = pJuridica;
            this.Context.Pessoas.Add(pJuridica);
            this.Context.SaveChanges();
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
