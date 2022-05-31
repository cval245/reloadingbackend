using Microsoft.EntityFrameworkCore;
using ReloadingBackend.Models;

namespace ReloadingBackend;

public class DatabaseContext: DbContext
{
    public DbSet<RangeTest> RangeTests { get; set; }
    public DbSet<RoundTest> RoundTests { get; set; }
    public DbSet<Round> Rounds { get; set; }
    public DbSet<Powder> Powders { get; set; }
    public DbSet<Primer> Primers { get; set; }
    public DbSet<Bullet> Bullets { get; set; }
   
    public string DbPath { get; }
    
        public DatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "reloadingBackend.db");
        }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Round>()
            .HasOne(b => b.RoundTest)
            .WithOne(i => i.Round)
            .HasForeignKey<RoundTest>(b => b.RoundId);
    }
}