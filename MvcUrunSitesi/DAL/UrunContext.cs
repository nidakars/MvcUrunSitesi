using System.Data.Entity;
using MvcUrunSitesi.Entities;

namespace MvcUrunSitesi.DAL
{
   public class UrunContext : DbContext
   {
      public UrunContext()
      {
         Database.SetInitializer(new UrunInitializer());
      }

      public DbSet<Admin> Admin { get; set; }
      public DbSet<Adres> Adres { get; set; }
      public DbSet<Category> Category { get; set; }
      public DbSet<Product> Product { get; set; }
      public DbSet<Sepet> Sepet { get; set; }
      public DbSet<Siparis> Siparis { get; set; }
      public DbSet<Slider> Slider { get; set; }
      public DbSet<User> User { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         //base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<Category>()
            .HasMany(p => p.Products)//Category Products ile bire çok ilişkili
            .WithRequired(c => c.Categories)//
            .WillCascadeOnDelete(true);
      }
   }
}