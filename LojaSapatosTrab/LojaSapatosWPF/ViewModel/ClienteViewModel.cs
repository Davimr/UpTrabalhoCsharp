﻿using LojaSapatos;
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
            Endereco end1 = new LojaSapatos.Endereco()
            {
                Rua = "Jose de Alencar",
                Numero = "374",
                Complemento = "463",
                Cep = "80945-095",
            };
            Endereco end2 = new LojaSapatos.Endereco()
            {
                Rua = "Amintas de Barros",
                Numero = "342",
                Complemento = "654",
                Cep = "89789-000",
            };
            PessoaFisica pf1 = new LojaSapatos.PessoaFisica()
            {
                Nome = "Rafael",
                DataNascimento = new DateTime(1982, 03, 03),
                Cpf = "000.000.000-00",
                Endereco = end1,
                
            };
            PessoaJuridica pj1 = new LojaSapatos.PessoaJuridica()
            {
                Nome = "Armazem do Ze",
                RazaoSocial = "Ze da Couve LTDA",
                Cnpj = "11.111.111/0001-11",
                Endereco = end2,
            };
           


            this.Context = new SapatoModel();
            this.Clientes = new ObservableCollection<Pessoa>(this.Context.Pessoas.ToList());

            Clientes.Add(pf1);
            Clientes.Add(pj1);

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
