using System.Collections.Generic;

namespace SongTracker.Models
{
  public class Instrument
  {
    public Instrument()
    {
      this.JoinEntities = new HashSet<InstrumentSong>();
    }

    public int InstrumentId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string AdditionalInfo { get; set; }
    public virtual ICollection<InstrumentSong> JoinEntities { get; set; }
  }
}