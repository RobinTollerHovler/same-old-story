using System.Collections.Generic;
using SameOldStory.Core.Time;

namespace SameOldStory.Core.Buffs {
    
    public class BuffManager {
        
        private HashSet<Buff> activeBuffs;

        public BuffManager() {
            activeBuffs = new HashSet<Buff>();
            Cycle.onTick += TickBuffs;
        }

        ~BuffManager() {
            Cycle.onTick -= TickBuffs;
        }

        public void ApplyBuff(Buff buff) {
            activeBuffs.Add(buff);
        }

        private void TickBuffs(float amount) {
            foreach (var buff in new List<Buff>(activeBuffs)) {
                if (buff is not TimedBuff timedBuff) continue;
                timedBuff.Tick(amount);
                if (timedBuff.Cooldown < 0) activeBuffs.Remove(buff);
            }
        }
        
    }
    
}