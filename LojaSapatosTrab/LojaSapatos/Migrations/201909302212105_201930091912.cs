namespace LojaSapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201930091912 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modeloes", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modeloes", "Nome");
        }
    }
}
