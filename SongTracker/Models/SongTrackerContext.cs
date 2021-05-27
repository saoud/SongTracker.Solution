using Microsoft.EntityFrameworkCore;

namespace SongTracker.Models
{
  public class SongTrackerContext : DbContext
  {
    public virtual DbSet<Song> Songs { get; set; }
    public DbSet<Instrument> Instruments{ get; set; }
    public DbSet<InstrumentSong> InstrumentSong{ get; set; }


    public SongTrackerContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}