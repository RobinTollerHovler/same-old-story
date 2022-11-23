using SameOldStory.Core.Data;

namespace SameOldStory.Core.Buffs {
    
    public class GenreDebuff : TimedBuff {

        public GenreDebuff(Genre genre) : base() {
            Key = genre.Name;
            Value = -2;
            Cooldown = 40;
        }
        
    }
    
}