using SameOldStory.Core.Data;

namespace SameOldStory.Core.Buffs {
    
    public class GenreDebuff : TimedBuff {

        public GenreDebuff(Genre genre) : base() {
            Key = genre.Name;
            Value = -3;
            Cooldown = 120;
        }
        
    }
    
}