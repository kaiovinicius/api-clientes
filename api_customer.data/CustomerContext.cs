using api_customer.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_customer.data
{
    public class CustomerContext : DbContext
    {
        #region Constructor
        public CustomerContext() { }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; } 
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Primary Key
            builder.Entity<Customer>().Property(t => t.Id)
                .ValueGeneratedOnAdd();

            // Properties
            builder.Entity<Customer>().Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11);
            builder.Entity<Customer>().Property(c => c.Genre)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Customer>().Property(t => t.Id).HasColumnName("id");
            builder.Entity<Customer>().Property(t => t.IdAddress).HasColumnName("idAddress");
            builder.Entity<Customer>().Property(t => t.Name).HasColumnName("name");
            builder.Entity<Customer>().Property(t => t.Surname).HasColumnName("surname");
            builder.Entity<Customer>().Property(t => t.Cpf).HasColumnName("cpf");
            builder.Entity<Customer>().Property(t => t.Genre).HasColumnName("genre");

            //Relationships 

            // Primary Key
            builder.Entity<Contact>().Property(t => t.Id)
                .ValueGeneratedOnAdd();

            // Properties
            builder.Entity<Contact>().Property(c => c.Ddd)
                .IsRequired()
                .HasMaxLength(3);
            builder.Entity<Contact>().Property(c => c.Number)
                .IsRequired()
                .HasMaxLength(20);
            builder.Entity<Contact>().Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            builder.Entity<Contact>().ToTable("Contact");
            builder.Entity<Contact>().Property(t => t.Id).HasColumnName("id");
            builder.Entity<Contact>().Property(t => t.IdCustomer).HasColumnName("idCustomer");
            builder.Entity<Contact>().Property(t => t.Ddd).HasColumnName("ddd");
            builder.Entity<Contact>().Property(t => t.Number).HasColumnName("number");
            builder.Entity<Contact>().Property(t => t.Email).HasColumnName("email");

            //Relationships
            builder.Entity<Contact>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.Customer)
                      .WithOne(c => c.Contact)
                      .HasForeignKey<Contact>(c => c.IdCustomer);
            }); 
        }
    }
}