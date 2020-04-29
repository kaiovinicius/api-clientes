using api_clientes.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_clientes.data
{
    public class EnderecosContext : DbContext
    {
        public EnderecosContext() { }

        public EnderecosContext(DbContextOptions<EnderecosContext> options) : base(options) { }

        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Endereco
            // Primary Key
            builder.Entity<Endereco>().Property(t => t.Id)
                .ValueGeneratedOnAdd();

            // Properties
            builder.Entity<Endereco>().Property(c => c.Cep)
                    .IsRequired()
                    .HasMaxLength(8);
            builder.Entity<Endereco>().Property(c => c.Logradouro)
                    .IsRequired()
                    .HasMaxLength(255);
            builder.Entity<Endereco>().Property(c => c.Bairro)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Entity<Endereco>().Property(c => c.Cidade)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Entity<Endereco>().Property(c => c.Estado)
                    .IsRequired()
                    .HasMaxLength(100);

            // Table & Column Mappings
            builder.Entity<Endereco>().ToTable("Endereco");
            builder.Entity<Endereco>().Property(t => t.Id).HasColumnName("id");
            builder.Entity<Endereco>().Property(t => t.Cep).HasColumnName("cep");
            builder.Entity<Endereco>().Property(t => t.Logradouro).HasColumnName("logradouro");
            builder.Entity<Endereco>().Property(t => t.Bairro).HasColumnName("bairro");
            builder.Entity<Endereco>().Property(t => t.Cidade).HasColumnName("cidade");
            builder.Entity<Endereco>().Property(t => t.Estado).HasColumnName("estado");

            //Relationships 
            #endregion
        }
    }
}
