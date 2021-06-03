namespace SongTracker.Models
{
  public class InstrumentSong
  {
    public int InstrumentSongId { get; set; }
    public int SongId { get; set; }
    public int InstrumentId { get; set; }
    public virtual Song Song { get; set; }
    public virtual Instrument Instrument { get; set; }
  }
}