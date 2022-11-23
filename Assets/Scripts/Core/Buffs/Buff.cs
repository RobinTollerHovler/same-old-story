using UnityEngine;

namespace SameOldStory.Core.Buffs {
    
    public abstract class Buff {

        public string Key { get; protected set;}
        public float Value { get; protected set;}
        
        protected Buff() {
            
        }

    }
    
}