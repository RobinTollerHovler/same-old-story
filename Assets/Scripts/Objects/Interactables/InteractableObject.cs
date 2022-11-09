using SameOldStory.Input.Mouse;
using UnityEngine;

namespace SameOldStory.Objects.Interactables {
    
    public class InteractableObject : MonoBehaviour, IHaveTooltip, IReactToMouseClick {

        [SerializeField] private string tooltip;

        public string Tooltip {
            get => tooltip;
            protected set => tooltip = value;
        }

        public virtual void MouseClick() {}

    }
    
}