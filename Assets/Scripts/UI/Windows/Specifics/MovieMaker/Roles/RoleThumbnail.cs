using SameOldStory.UI.Buttons;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RoleThumbnail : MonoBehaviour {

        private AddRoleButtonNode node;

        public void Hide() => node?.gameObject.SetActive(false);
        public void Show() => node?.gameObject.SetActive(true);

    }
    
}