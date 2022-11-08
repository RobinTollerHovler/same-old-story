using UnityEngine;

namespace SameOldStory.Movies {
    
    public class TypewriterPage : MonoBehaviour {

        [SerializeField] private GameObject node;
        [SerializeField] private Transform moveNode;
        
        public void Deactivate() => node?.SetActive(false);
        public void Activate() => node?.SetActive(true);

    }
    
}