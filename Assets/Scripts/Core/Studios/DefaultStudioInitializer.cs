using UnityEngine;

namespace SameOldStory.Core.Studios {
    
    public class DefaultStudioInitializer : MonoBehaviour {

        [SerializeField] private int actorWagePerFameLevel = 0;
        
        private void Awake() => Studio.InitializeNewStudio(actorWagePerFameLevel);
        
    }
    
}