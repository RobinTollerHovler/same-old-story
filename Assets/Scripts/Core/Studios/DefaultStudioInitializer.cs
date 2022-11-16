using UnityEngine;

namespace SameOldStory.Core.Studios {
    
    public class DefaultStudioInitializer : MonoBehaviour {

        private void Awake() => Studio.InitializeNewStudio();

    }
    
}