using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebOlympiada.Models;

namespace WebOlympiada.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public virtual DbSet<Sport> Sports { get; set; }

        public virtual DbSet<Models.Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Sports__3213E83F603D15AB");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type).WithMany(p => p.Sports)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sports.Types");
            });

            modelBuilder.Entity<Models.Type>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Types__3214EC07AA286D7B");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

        }


    }
}
