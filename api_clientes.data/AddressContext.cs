using api_customer.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_customer.data
{
    public class AddressContext : DbContext
    {
        public AddressContext() { }

        public AddressContext(DbContextOptions<AddressContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Address
            // Primary Key
            builder.Entity<Address>().Property(t => t.Id)
                .ValueGeneratedOnAdd();

            // Properties
            builder.Entity<Address>().Property(c => c.ZipCode)
                    .IsRequired()
                    .HasMaxLength(8);
            builder.Entity<Address>().Property(c => c.PublicArea)
                    .IsRequired()
                    .HasMaxLength(255);
            builder.Entity<Address>().Property(c => c.Neighborhood)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Entity<Address>().Property(c => c.City)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Entity<Address>().Property(c => c.State)
                    .IsRequired()
                    .HasMaxLength(100);

            // Table & Column Mappings
            builder.Entity<Address>().ToTable("Endereco");
            builder.Entity<Address>().Property(t => t.Id).HasColumnName("id");
            builder.Entity<Address>().Property(t => t.ZipCode).HasColumnName("zipCode");
            builder.Entity<Address>().Property(t => t.PublicArea).HasColumnName("publicArea");
            builder.Entity<Address>().Property(t => t.Neighborhood).HasColumnName("neighborhood");
            builder.Entity<Address>().Property(t => t.City).HasColumnName("city");
            builder.Entity<Address>().Property(t => t.State).HasColumnName("state");

            //Relationships 
            #endregion
        }
    }
}
