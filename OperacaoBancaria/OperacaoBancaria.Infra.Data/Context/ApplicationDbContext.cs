using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OperacaoBancaria.Domain.ContaCorrente.Model;
using OperacaoBancaria.Domain.Lancamentos.Model;
using OperacaoBancaria.Infra.Data.Extensions;
using OperacaoBancaria.Infra.Data.Mappings;
using System.IO;

namespace OperacaoBancaria.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Lancamentos> Lancamentos { get; set; }

        public ApplicationDbContext() {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ContaCorrenteMapping());
            modelBuilder.AddConfiguration(new LancamentosMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DbConnection"));
        }
    }
}
