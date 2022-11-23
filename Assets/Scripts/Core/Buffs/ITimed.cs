namespace SameOldStory.Core.Buffs {
    
    public interface ITimed {
        
        public float Cooldown { get; }
        public void Tick(float amount);

    }
    
}

