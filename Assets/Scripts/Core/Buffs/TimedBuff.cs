namespace SameOldStory.Core.Buffs {
    
    public class TimedBuff : Buff, ITimed {
        
        public void Tick(float amount) => Cooldown -= amount;
        public float Cooldown { get; protected set; }
        
    }
    
}