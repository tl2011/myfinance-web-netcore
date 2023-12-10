using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Infraestrutura
{
    public class MyFinanceDbContext : DbContext // cria toda configuraçao para acesso aos dados
    {
        public DbSet<PlanoConta> PlanoConta { get;set;}
        public DbSet<Transacao> Transacao { get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=localhost\sqlexpress;Database=myfinanceweb;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
        
    }
}