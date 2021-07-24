using Microsoft.EntityFrameworkCore;
using SilviaCosmeticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilviaCosmeticos
{
    public class AplicacaoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProdutosDB;Trusted_Connection=true;");
        }
    }
}
