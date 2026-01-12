using Microsoft.EntityFrameworkCore;
using SpinWinKiosk.Services;



namespace SpinWinKiosk.API.Data
{
    public class AppDbContext : DbContext
    {

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Player> Players => Set<Player>();
        public DbSet<PlaySession> PlaySessions => Set<PlaySession>();
        public DbSet<PlayHistory> PlayHistories => Set<PlayHistory>();
        public DbSet<Prize> Prizes => Set<Prize>();
    }
}
