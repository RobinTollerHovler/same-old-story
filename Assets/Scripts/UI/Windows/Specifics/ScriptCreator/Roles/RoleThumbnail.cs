using Core.Roles;
using SameOldStory.UI.Menus;
using UI.Windows.Specifics.ScriptCreator.Roles;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RoleThumbnail : MonoBehaviour {

        private AddRoleButtonNode node;
        private RoleInformationTextComponent roleInformationTextComponent;
        
        private void Awake() {
            node = GetComponentInChildren<AddRoleButtonNode>();
            roleInformationTextComponent = GetComponentInChildren<RoleInformationTextComponent>();
        }

        public void Hide() {
            foreach(IMenu menu in GetComponentsInChildren<IMenu>()) menu.Close();
            node?.gameObject.SetActive(false);
        }

        public void Show(Role attachedRole = null) {
            roleInformationTextComponent?.SetText(attachedRole?.RoleTitle ?? "Add role");
            node?.gameObject.SetActive(true);
        }
        
    }
    
}