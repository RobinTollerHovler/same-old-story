using SameOldStory.UI.Menus;
using UnityEngine;

namespace UI.Windows.Specifics.MovieMaker.Roles {
    
    public class ActorForRoleMenu : MonoBehaviour, IMenu {
        
        public void Open() {
            gameObject.SetActive(true);
            
        }

        public void Close() => gameObject.SetActive(false);
        
    }
    
}