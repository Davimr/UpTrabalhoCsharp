namespace LojaSapatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class SapatoModel : DbContext
    {
        // Your context has been configured to use a 'SapatoModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LojaSapatos.SapatoModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SapatoModel' 
        // connection string in the application configuration file.
        public SapatoModel()
            : base("name=SapatoModel")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ItemEstoque>()
                .HasRequired<Sapato>(i => i.Sapato)
                .WithOptional(s => s.ItemEstoque)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Sapato>()
                .HasOptional(s => s.Modelo)
                .WithOptionalDependent()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ItemPedido>()
                .HasRequired<Sapato>(i => i.Sapato)
                .WithMany(s => s.ItensPedido)
                .WillCascadeOnDelete(true);

            
        }


        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Sapato> Sapatos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
       

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}