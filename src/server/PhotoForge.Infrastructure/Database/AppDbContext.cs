using Microsoft.EntityFrameworkCore;

using PhotoForge.Core.Features.Auth;
using PhotoForge.Core.Features.Galleries;
using PhotoForge.Core.Features.Users;

namespace PhotoForge.Infrastructure.Database;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserSession> UserSessions { get; set; } = null!;
    public DbSet<Gallery> Galleries { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}