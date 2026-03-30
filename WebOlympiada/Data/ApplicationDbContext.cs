using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebOlympiada.Models;
using Type = WebOlympiada.Models.Type;

namespace WebOlympiada.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {

        public virtual DbSet<Rozhodci> Rozhodci { get; set; }
        public virtual DbSet<Divaci> Divaci { get; set; }

        public virtual DbSet<Sport> Sportovec { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }


        public virtual DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rozhodci>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Rozhodc__3214EC07B9C8F1B7");
                entity.ToTable("Rozhodci");
                entity.Property(e => e.Jmeno).IsRequired();
                entity.Property(e => e.Prijmeni).IsRequired();
            });

            modelBuilder.Entity<Divaci>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Divaci__3214EC072BFDF6C1");

                entity.ToTable("Divaci");

                entity.Property(e => e.Jmeno).HasMaxLength(50);
                entity.Property(e => e.Prijmeni).HasMaxLength(50);
            });

            modelBuilder.Entity<Sportovec>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Sportove__3214EC07B9C8F1B7");
                entity.ToTable("Sportovec");
                entity.Property(e => e.Jmeno).IsRequired();
                entity.Property(e => e.Prijmeni).IsRequired();
                entity.Property(e => e.Narodnost).IsRequired();
            });


            modelBuilder.Entity<Sport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Sports__3213E83F603D15AB");

                entity.HasIndex(e => e.TypeId, "IX_Sports_TypeID");

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

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Types__3214EC07AA286D7B");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}

