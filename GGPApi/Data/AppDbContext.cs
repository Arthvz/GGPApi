using GGPApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GGPApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define a propriedade Users como um DbSet do tipo UserModel.
        // Isso permite que a tabela "Users" seja mapeada para a classe UserModel no banco de dados.
        public DbSet<UserModel> Users { get; set; }

        // Define a propriedade Receitas como um DbSet do tipo ReceitaModel.
        // Isso permite que a tabela "Receitas" seja mapeada para a classe ReceitaModel no banco de dados.
        public DbSet<ReceitaModel> Receitas { get; set; }

        // Define a propriedade Despesas como um DbSet do tipo DespesaModel.
        // Isso permite que a tabela "Despesas" seja mapeada para a classe DespesaModel no banco de dados.
        public DbSet<DespesaModel> Despesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre UserModel e ReceitaModel
            modelBuilder.Entity<ReceitaModel>()
                .HasOne(r => r.User)
                .WithMany(u => u.Receitas)
                .HasForeignKey(r => r.UserId);

            // Relacionamento entre UserModel e DespesaModel
            modelBuilder.Entity<DespesaModel>()
                .HasOne(d => d.User)
                .WithMany(u => u.Despesas)
                .HasForeignKey(d => d.UserId);
        }
    }
}
