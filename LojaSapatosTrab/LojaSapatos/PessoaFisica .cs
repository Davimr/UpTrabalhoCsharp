using System;

namespace LojaSapatos
{
    public class PessoaFisica : Pessoa
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}