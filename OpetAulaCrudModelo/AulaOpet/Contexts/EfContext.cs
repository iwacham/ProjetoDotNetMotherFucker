using AulaOpet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AulaOpet.Contexts
{
    public class EfContext : DbContext
    {

        #region [Construtor]
        public EfContext() : base("MEUCRUD")
        {
            Database.SetInitializer<EfContext>(
               new DropCreateDatabaseIfModelChanges<EfContext>());
        }
        #endregion

        #region [DbSet's]
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        #endregion

       
    }
}