using SameOldStory.Core.Data;

namespace SameOldStory.Core.Buffs {
    
    public class GenreDebuff : TimedBuff {

        public GenreDebuff(Genre genre) : base() {
            Key = $"DEBUFF_GENRE_{genre.Name.ToUpper()}";
            Value = -1;
            Cooldown = 10;
        }
        
    }
    
}