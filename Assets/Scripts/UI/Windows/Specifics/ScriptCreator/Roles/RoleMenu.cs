using SameOldStory.UI.Menus;
using UnityEngine;

namespace UI.Menus {
    
    public class RoleMenu : MonoBehaviour, IMenu {

        public void Open() => gameObject.SetActive(true);
        public void Close() => gameObject.SetActive(false);
        
    }
    
}