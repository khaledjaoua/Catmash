using CatMash.Repository.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatMash.Repository
{
    public class CatMashDbContext : IdentityDbContext
    {
        public CatMashDbContext(DbContextOptions<CatMashDbContext> options)
            : base(options)
        {
        }
        public CatMashDbContext() : base()
        {
        }
        public DbSet<Cats> Cats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cats>().ToTable("cats");
            modelBuilder.Entity<Cats>().HasKey(x => x.CatMashId);
            modelBuilder.Entity<Cats>().Property(b => b.CatMashId).HasColumnType("int");
            modelBuilder.Entity<Cats>().Property(b => b.Note).HasColumnName("note").HasColumnType("int").HasDefaultValueSql("((0))");
            modelBuilder.Entity<Cats>().Property(b => b.Id).HasColumnName("id").HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Cats>().Property(b => b.Url).HasColumnName("url").HasColumnType("text");
            base.OnModelCreating(modelBuilder);
        }
    }
}
