using UnityEngine;

namespace SameOldStory.Core.Buffs {
    
    public abstract class Buff {

        public string Key { get; protected set;}
        public int Value { get; protected set;}
        
        protected Buff() {
            
        }

    }
    
}