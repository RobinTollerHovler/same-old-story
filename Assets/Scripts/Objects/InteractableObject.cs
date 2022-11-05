using SameOldStory.Input.Mouse;
using UnityEngine;

namespace SameOldStory.Objects {
    
    public class InteractableObject : MonoBehaviour, IHaveTooltip {

        [SerializeField] private string tooltip;

        public string Tooltip => tooltip;

    }
    
}