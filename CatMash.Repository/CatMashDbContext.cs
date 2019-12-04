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
            modelBuilder.Entity<Cats>().HasKey(x => x.CatMashId).HasName("catmashid");
            modelBuilder.Entity<Cats>().Property(b => b.Note).HasColumnName("note").HasDefaultValueSql("((0))");
            modelBuilder.Entity<Cats>().Property(b => b.Id).HasColumnName("id");
            modelBuilder.Entity<Cats>().Property(b => b.Url).HasColumnName("url");
            base.OnModelCreating(modelBuilder);
        }
    }
}
