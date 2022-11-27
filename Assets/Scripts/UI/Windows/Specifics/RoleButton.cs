using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RoleButton : MonoBehaviour {

        private RoleButtonNode node;

        private void Awake() => node = GetComponentInChildren<RoleButtonNode>();
        
        public void Hide() => node?.gameObject.SetActive(false);
        public void Show() => node?.gameObject.SetActive(true);

    }
    
}