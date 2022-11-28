using SameOldStory.Core.Studios;
using UnityEngine;

namespace UI.Menus {
    
    public class RoleMenu : MonoBehaviour {

        public void Open() {
            gameObject.SetActive(true);
            Debug.Log(Studio.Current.AvailableRoles[0].RoleTitle);
        }
        
    }
    
}