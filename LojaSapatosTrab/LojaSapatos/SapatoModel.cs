namespace LojaSapatos
{
    using System;
    using System.Data.Entity;
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

        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Sapato> Sapatos { get; set; }
        public virtual DbSet<ItemEstoque> Estoques { get; set; }
        public virtual DbSet<ItemPedido> ItensPedido { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<PessoaFisica> PessoasFisica { get; set; }
        public virtual DbSet<PessoaJuridica> PessoasJuridica { get; set; }

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