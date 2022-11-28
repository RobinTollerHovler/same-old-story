using Core.Roles;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RoleThumbnail : MonoBehaviour {

        private AddRoleButtonNode node;

        private void Awake() => node = GetComponentInChildren<AddRoleButtonNode>();

        public void Hide() => node?.gameObject.SetActive(false);
        
        public void Show(Role attachedRole = null) {
            node?.gameObject.SetActive(true);
        }
        
    }
    
}