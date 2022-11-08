using UnityEngine;

namespace SameOldStory.UI.Elements.Panels {
    
    public class CancelButton : MonoBehaviour {

        public void Cancel() => GetComponentInParent<PanelContainer>()?.gameObject.SetActive(false);

    }
    
}