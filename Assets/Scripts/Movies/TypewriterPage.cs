using UnityEngine;

namespace SameOldStory.Movies {
    
    public class TypewriterPage : MonoBehaviour {

        [SerializeField] private GameObject node;
        [SerializeField] private Transform moveNode;
        [SerializeField] private float maxOffset;
        
        public void Deactivate() => node?.SetActive(false);
        public void Activate() => node?.SetActive(true);

        public void SetAtFactor(float factor) {
            moveNode.transform.localPosition = new Vector3(0, maxOffset * factor, 0);
        }

    }
    
}