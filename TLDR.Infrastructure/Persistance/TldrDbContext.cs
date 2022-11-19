using Microsoft.EntityFrameworkCore;
using TLDR.Domain.Entities.Authentication;
using TLDR.Domain.Entities.QnA;

namespace TLDR.Infrastructure.Persistance
{
    public sealed class TldrDbContext : DbContext
    {
        public TldrDbContext(DbContextOptions<TldrDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Question> Questions { get; set; } = default!;
        public DbSet<Answer> Answers { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TldrDbContext).Assembly);
        }
    }
}