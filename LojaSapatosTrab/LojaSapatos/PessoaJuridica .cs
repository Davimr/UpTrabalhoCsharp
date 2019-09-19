using System;

namespace LojaSapatos
{
    public class PessoaJuridica : Pessoa
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
    }
}