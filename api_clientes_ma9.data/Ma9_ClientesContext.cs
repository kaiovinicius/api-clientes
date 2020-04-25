using api_clientes_ma9.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_clientes_ma9.data
{
    public class Ma9_ClientesContext : DbContext
    {
        public Ma9_ClientesContext() { }

        public Ma9_ClientesContext(DbContextOptions<Ma9_ClientesContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Primary Key
            builder.Entity<Cliente>().Property(t => t.Id)
                .ValueGeneratedOnAdd();

            // Properties
            builder.Entity<Cliente>().Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Entity<Cliente>().Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Entity<Cliente>().Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11);
            builder.Entity<Cliente>().Property(c => c.Sexo)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            builder.Entity<Cliente>().ToTable("Cliente");
            builder.Entity<Cliente>().Property(t => t.Id).HasColumnName("id");
            builder.Entity<Cliente>().Property(t => t.Nome).HasColumnName("nome");
            builder.Entity<Cliente>().Property(t => t.Sobrenome).HasColumnName("sobrenome");
            builder.Entity<Cliente>().Property(t => t.Cpf).HasColumnName("cpf");
            builder.Entity<Cliente>().Property(t => t.Sexo).HasColumnName("sexo");

            //Relationships




            // Primary Key
            builder.Entity<Cliente>().Property(t => t.Id)
                .ValueGeneratedOnAdd();

            // Properties
            builder.Entity<Contato>().Property(c => c.Ddd)
                .IsRequired()
                .HasMaxLength(3);
            builder.Entity<Contato>().Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(20);
            builder.Entity<Contato>().Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.Entity<Contato>().ToTable("Contato");
            builder.Entity<Contato>().Property(t => t.Id).HasColumnName("id");
            builder.Entity<Contato>().Property(t => t.IdCliente).HasColumnName("idCliente");
            builder.Entity<Contato>().Property(t => t.Ddd).HasColumnName("ddd");
            builder.Entity<Contato>().Property(t => t.Numero).HasColumnName("numero");
            builder.Entity<Contato>().Property(t => t.Email).HasColumnName("email");

            //Relationships
            builder.Entity<Contato>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.Cliente)
                      .WithOne(c => c.Contato)
                      .HasForeignKey<Contato>(c => c.IdCliente);
            });
        }
    }
}