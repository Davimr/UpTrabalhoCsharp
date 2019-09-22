namespace LojaSapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(),
                        DataNascimento = c.DateTime(),
                        Cnpj = c.String(),
                        RazaoSocial = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Endereco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rua = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Cep = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataVenda = c.DateTime(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantidadeTotal = c.Int(nullable: false),
                        ClienteJuridica_Id = c.Int(),
                        ClienteFisica_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.ClienteJuridica_Id)
                .ForeignKey("dbo.Pessoas", t => t.ClienteFisica_Id)
                .Index(t => t.ClienteJuridica_Id)
                .Index(t => t.ClienteFisica_Id);
            
            CreateTable(
                "dbo.ItemPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Sapato_Id = c.Int(),
                        Venda_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sapatoes", t => t.Sapato_Id)
                .ForeignKey("dbo.Vendas", t => t.Venda_Id)
                .Index(t => t.Sapato_Id)
                .Index(t => t.Venda_Id);
            
            CreateTable(
                "dbo.Sapatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tamanho = c.Int(nullable: false),
                        Modelo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modeloes", t => t.Modelo_Id)
                .Index(t => t.Modelo_Id);
            
            CreateTable(
                "dbo.ItemEstoques",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sapatoes", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PossuiCadarco = c.Boolean(nullable: false),
                        Material = c.String(),
                        Cor = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fotografia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "ClienteFisica_Id", "dbo.Pessoas");
            DropForeignKey("dbo.ItemPedidoes", "Venda_Id", "dbo.Vendas");
            DropForeignKey("dbo.Sapatoes", "Modelo_Id", "dbo.Modeloes");
            DropForeignKey("dbo.ItemPedidoes", "Sapato_Id", "dbo.Sapatoes");
            DropForeignKey("dbo.ItemEstoques", "Id", "dbo.Sapatoes");
            DropForeignKey("dbo.Vendas", "ClienteJuridica_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Pessoas", "Endereco_Id", "dbo.Enderecoes");
            DropIndex("dbo.ItemEstoques", new[] { "Id" });
            DropIndex("dbo.Sapatoes", new[] { "Modelo_Id" });
            DropIndex("dbo.ItemPedidoes", new[] { "Venda_Id" });
            DropIndex("dbo.ItemPedidoes", new[] { "Sapato_Id" });
            DropIndex("dbo.Vendas", new[] { "ClienteFisica_Id" });
            DropIndex("dbo.Vendas", new[] { "ClienteJuridica_Id" });
            DropIndex("dbo.Pessoas", new[] { "Endereco_Id" });
            DropTable("dbo.Modeloes");
            DropTable("dbo.ItemEstoques");
            DropTable("dbo.Sapatoes");
            DropTable("dbo.ItemPedidoes");
            DropTable("dbo.Vendas");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Pessoas");
        }
    }
}
