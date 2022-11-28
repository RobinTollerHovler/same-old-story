using Core.Roles;
using SameOldStory.UI.Menus;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RoleThumbnail : MonoBehaviour {

        private AddRoleButtonNode node;

        private void Awake() => node = GetComponentInChildren<AddRoleButtonNode>();

        public void Hide() {
            foreach(IMenu menu in GetComponentsInChildren<IMenu>()) menu.Close();
            node?.gameObject.SetActive(false);
        }

        public void Show(Role attachedRole = null) {
            node?.gameObject.SetActive(true);
        }
        
    }
    
}