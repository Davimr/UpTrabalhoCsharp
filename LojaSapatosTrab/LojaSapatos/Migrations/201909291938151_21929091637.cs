namespace LojaSapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21929091637 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemPedidoes", "Sapato_Id", "dbo.Sapatoes");
            DropForeignKey("dbo.ItemEstoques", "Id", "dbo.Sapatoes");
            DropForeignKey("dbo.Sapatoes", "Modelo_Id", "dbo.Modeloes");
            DropIndex("dbo.ItemPedidoes", new[] { "Sapato_Id" });
            AlterColumn("dbo.ItemPedidoes", "Sapato_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemPedidoes", "Sapato_Id");
            AddForeignKey("dbo.ItemPedidoes", "Sapato_Id", "dbo.Sapatoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemEstoques", "Id", "dbo.Sapatoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sapatoes", "Modelo_Id", "dbo.Modeloes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sapatoes", "Modelo_Id", "dbo.Modeloes");
            DropForeignKey("dbo.ItemEstoques", "Id", "dbo.Sapatoes");
            DropForeignKey("dbo.ItemPedidoes", "Sapato_Id", "dbo.Sapatoes");
            DropIndex("dbo.ItemPedidoes", new[] { "Sapato_Id" });
            AlterColumn("dbo.ItemPedidoes", "Sapato_Id", c => c.Int());
            CreateIndex("dbo.ItemPedidoes", "Sapato_Id");
            AddForeignKey("dbo.Sapatoes", "Modelo_Id", "dbo.Modeloes", "Id");
            AddForeignKey("dbo.ItemEstoques", "Id", "dbo.Sapatoes", "Id");
            AddForeignKey("dbo.ItemPedidoes", "Sapato_Id", "dbo.Sapatoes", "Id");
        }
    }
}
