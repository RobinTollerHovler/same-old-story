using UnityEngine;

namespace SameOldStory.UI.Windows {
    
    public class WindowActivationNode : MonoBehaviour {

        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);

    }
    
}