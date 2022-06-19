using Microsoft.EntityFrameworkCore;

namespace SqlClientError;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Composer> Composers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=tcp:localhost,1433;Initial Catalog=SqlClientError;Persist Security Info=False;User ID=sa;Password=Very-Complex-Password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Japanese_90_BIN2");

        modelBuilder.Entity<Composer>(entity =>
        {
            entity.ToTable("composer");

            entity.Property(e => e.ComposerId)
                .ValueGeneratedNever()
                .HasColumnName("composer_id");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });
    }
}

public partial class Composer
{
    public int ComposerId { get; set; }
    public string? Name { get; set; }
}