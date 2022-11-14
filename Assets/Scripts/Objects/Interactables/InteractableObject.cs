using SameOldStory.Input.Mouse;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using UnityEngine;

namespace SameOldStory.Objects.Interactables {
    
    public class InteractableObject : MonoBehaviour, IHaveTooltip, IReactToMouseClick {

        protected ClickBehaviour clickBehaviour = new NoClickBehaviour();
        
        [SerializeField] private string tooltip;

        public string Tooltip {
            get => tooltip;
            protected set => tooltip = value;
        }

        public virtual void MouseClick() => clickBehaviour.Click();

    }
    
}