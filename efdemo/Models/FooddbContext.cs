using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace efdemo.Models
{
    public partial class FooddbContext : DbContext
    {
        public FooddbContext()
        {
        }

        public FooddbContext(DbContextOptions<FooddbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Foodstuffs> Foodstuffs { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               optionsBuilder.UseSqlServer("Server=.\\BAKUSOFTFOODS;Database=Fooddb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foodstuffs>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DefUnit).HasMaxLength(2);

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ingredients).HasMaxLength(2048);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Reference)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(256);
            });
        }
    }
}
