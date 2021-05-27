using System.Collections.Generic;

namespace SongTracker.Models
{
    public class Song //change name to parent class
    {
        public Song() //when does this get called?
        {
            this.JoinEntities = new HashSet<InstrumentSong>(); // First Child is plural and second child is singular
        }

        public int SongId { get; set; } //replace parent class
        public string Name { get; set; } 
        public string Artist { get; set; }
        public string Genre { get; set; }//Replace with field name
        public string Chords { get; set; }
        public virtual ICollection<InstrumentSong> JoinEntities { get; set; }
    }
}