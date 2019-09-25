namespace LojaSapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201925091943 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendas", "ClienteFisica_Id", "dbo.Pessoas");
            DropIndex("dbo.Vendas", new[] { "ClienteFisica_Id" });
            RenameColumn(table: "dbo.Vendas", name: "ClienteJuridica_Id", newName: "Cliente_Id");
            RenameIndex(table: "dbo.Vendas", name: "IX_ClienteJuridica_Id", newName: "IX_Cliente_Id");
            DropColumn("dbo.Vendas", "ClienteFisica_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendas", "ClienteFisica_Id", c => c.Int());
            RenameIndex(table: "dbo.Vendas", name: "IX_Cliente_Id", newName: "IX_ClienteJuridica_Id");
            RenameColumn(table: "dbo.Vendas", name: "Cliente_Id", newName: "ClienteJuridica_Id");
            CreateIndex("dbo.Vendas", "ClienteFisica_Id");
            AddForeignKey("dbo.Vendas", "ClienteFisica_Id", "dbo.Pessoas", "Id");
        }
    }
}
