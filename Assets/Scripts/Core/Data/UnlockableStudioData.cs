using UnityEngine;

namespace SameOldStory.Core.Data {
    
    public abstract class UnlockableStudioData : StudioData {
        
        [Header("Unlockable data options")]
        [SerializeField] private bool startAvailable;
        
        public bool StartAvailable => startAvailable;

    }
    
}