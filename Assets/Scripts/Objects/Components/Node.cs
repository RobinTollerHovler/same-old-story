using UnityEngine;

namespace SameOldStory.Objects.Components {
    
    public class Node : MonoBehaviour {

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

    }
    
}