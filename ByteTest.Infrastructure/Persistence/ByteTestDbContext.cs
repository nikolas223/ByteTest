using ByteTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ByteTest.Infrastructure.Persistence;

public class ByteTestDbContext: DbContext
{
    public ByteTestDbContext(
        DbContextOptions<ByteTestDbContext> options
    ) : base(options) { }
    
    public DbSet<Resume> Resumes { get; set; } = default!;
    public DbSet<Degree> Degrees { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Resume>()
            .HasOne(x=> x.Degree)
            .WithMany(x=> x.Resumes)
            .HasForeignKey(x => x.DegreeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}