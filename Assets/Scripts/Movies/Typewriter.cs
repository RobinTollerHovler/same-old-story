using UnityEngine;

namespace SameOldStory.Movies {
    
    public class Typewriter : MonoBehaviour {

        [SerializeField] private TypewriterPage remainingTypewriterPage;
        [SerializeField] private TypewriterPage completedTypewriterPage;

        private void Awake() {
            remainingTypewriterPage?.Deactivate();
            completedTypewriterPage?.Deactivate();
        }

    }
    
}