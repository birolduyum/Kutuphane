using Kutuphane.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Data.Context
{
    public class KutuphaneDbContext:DbContext
    {
        public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options):base(options)
        {

        }

        public virtual DbSet<Books> Books  { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.ToTable("Authors", "Public");
                entity.HasKey(e => e.Id).HasName("PK_Authors");
                entity.Property(e => e.Id).HasColumnName("AuthorID").HasColumnType("uuid").HasDefaultValueSql("UUID_GENERATE_V4()").IsRequired();
                entity.Property(e => e.CreateDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()").IsRequired();
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.Surname).HasMaxLength(150);
                entity.Property(e => e.EmailAdress).HasMaxLength(150);
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });
            
            modelBuilder.Entity<Books>(entity =>
            {
                entity.ToTable("Books", "Public");
                entity.HasKey(e => e.Id).HasName("PK_Books");
                entity.Property(e => e.Id).HasColumnName("BookID").HasColumnType("uuid").HasDefaultValueSql("UUID_GENERATE_V4()").IsRequired();
                entity.Property(e => e.CreateDate).HasColumnType("datetime").HasDefaultValueSql("GetDate()").IsRequired();
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.Description).HasMaxLength(150);
                entity.Property(e => e.ISBN).HasMaxLength(13);
                entity.Property(e => e.PageCount).HasColumnType("int");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_Publisher");
                
                entity.HasOne(c => c.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(c => c.CategoryId)
                    .HasConstraintName("FK_Books_Categories");
                
                entity.HasOne(p => p.Publisher)
                    .WithMany(b => b.Books)
                    .HasForeignKey(p => p.PublisherId)
                    .HasConstraintName("FK_Books_Publisher");
            });
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories", "Public");
                entity.HasKey(e => e.Id).HasName("PK_Categories");
                entity.Property(e => e.Id).HasColumnName("CategoryID").HasColumnType("uuid").HasDefaultValueSql("UUID_GENERATE_V4()").IsRequired();
                entity.Property(e => e.CreateDate).HasColumnType("datetime").HasDefaultValue("GetDate()").IsRequired();
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });
            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher", "Public");
                entity.HasKey(e => e.Id).HasName("PK_Publisher");
                entity.Property(e => e.Id).HasColumnName("PublisherID").HasColumnType("uuid").HasDefaultValueSql("UUID_GENERATE_V4()").IsRequired();
                entity.Property(e => e.CreateDate).HasColumnName("CreateDate").HasColumnType("datetime").HasDefaultValueSql("GetDate()").IsRequired();
                entity.Property(e => e.Name).HasMaxLength(150);
                entity.Property(e => e.Phone).HasMaxLength(150);
                entity.Property(e => e.Address).HasMaxLength(150);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Public");
                entity.HasKey(e => e.Id).HasName("PK_Users");
                entity.Property(e => e.Id).HasColumnName("UserID").HasColumnType("uuid").HasDefaultValueSql("UUID_GENERATE_V4()").IsRequired();
                entity.Property(e => e.CreateDate).HasColumnName("CreateDate").HasColumnType("datetime").HasDefaultValueSql("GetDate()").IsRequired();
                entity.Property(e => e.FirstName).HasMaxLength(150);
                entity.Property(e => e.LastName).HasMaxLength(150);
                entity.Property(e => e.EmailAdress).HasMaxLength(150);
                entity.Property(e => e.Password).HasMaxLength(150);
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

    

            base.OnModelCreating(modelBuilder);
        }



    }

    

}
