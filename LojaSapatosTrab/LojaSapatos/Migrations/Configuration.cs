namespace LojaSapatos.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaSapatos.SapatoModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LojaSapatos.SapatoModel";
        }



        protected override void Seed(LojaSapatos.SapatoModel context)
        {

            Endereco end1 = new Endereco()
            {
                Rua = "Jose de Alencar",
                Numero = "374",
                Complemento = "463",
                Cep = "80945-095",
            };
            Endereco end2 = new Endereco()
            {
                Rua = "Amintas de Barros",
                Numero = "342",
                Complemento = "654",
                Cep = "89789-000",
            };
            PessoaFisica pf1 = new PessoaFisica()
            {
                Nome = "Rafael",
                DataNascimento = new DateTime(1982, 03, 03),
                Cpf = "000.000.000-00",
                Endereco = end1,

            };
            PessoaJuridica pj1 = new PessoaJuridica()
            {
                Nome = "Armazem do Ze",
                RazaoSocial = "Ze da Couve LTDA",
                Cnpj = "11.111.111/0001-11",
                Endereco = end2,
            };
            Modelo modelo1 = new Modelo()
            {
                Cor = "Preto",
                Material = "Couro",
                PossuiCadarco = false,
                Preco = 109.90M,
            };
            Modelo modelo2 = new Modelo()
            {
                Cor = "Branco",
                Material = "Tecido",
                PossuiCadarco = true,
                Preco = 99.90M
            };
            Sapato sapato1 = new Sapato()
            {
                Tamanho = 40,
                Modelo = modelo2,
                Marca = "Adidas"
            };
            ItemEstoque item1Estoque = new ItemEstoque()
            {
                Quantidade = 28,
                Sapato = sapato1,
            };
            Venda venda1 = new Venda()
            {
                ClienteFisica = pf1,
                DataVenda = new DateTime(2019, 09, 22),
                QuantidadeTotal = 2,
                ValorTotal = 234,
            };
            ItemPedido itemPedido = new ItemPedido()
            {
                Quantidade = 1,
                Sapato = sapato1,
                Venda = venda1,
            };

            venda1.ItensPedido = new List<ItemPedido>();
            venda1.ItensPedido.Add(itemPedido);

            AdicionarPessoaBanco(context, pf1);
            AdicionarPessoaBanco(context, pj1);

            AdicionarSapatoBanco(context, sapato1);

            AdicionarVendaBanco(context, venda1);

            context.SaveChanges();






            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        private static void AdicionarPessoaBanco(SapatoModel context, Pessoa p)
        {
            Pessoa pessoa =
                            (from db in context.Pessoas
                             where db.Nome == p.Nome
                             select db).FirstOrDefault();
            if (pessoa == null)
            {
                context.Pessoas.Add(p);
            }
        }

        private static void AdicionarSapatoBanco(SapatoModel context, Sapato sap)
        {
            Sapato sapato =
                            (from db in context.Sapatos
                             where db.Id == sap.Id
                             select db).FirstOrDefault();
            if (sapato == null)
            {
                context.Sapatos.Add(sap);
            }
        }

        private static void AdicionarVendaBanco(SapatoModel context, Venda vend)
        {
            Venda venda =
                            (from db in context.Vendas
                             where db.Id == vend.Id
                             select db).FirstOrDefault();
            if (venda == null)
            {
                context.Vendas.Add(vend);
            }
        }
    }
}
