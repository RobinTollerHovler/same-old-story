using Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;

namespace SameOldStory.Objects.Interactables {
    
    public class Bin : InteractableObject {
        
        private void OnEnable() => Script.onCurrentlyWritingScriptChanged += AssignScriptToBin;
        private void OnDisable() => Script.onCurrentlyWritingScriptChanged -= AssignScriptToBin;

        private void AssignScriptToBin(Script script) {
            if (script == null) {
                ClickAction = new NoClickAction();
                Tooltip = "Bin";
            } else {
                ClickAction = new DiscardScriptClickAction();
                Tooltip = $"Discard: {script.Title}";
            }
        }

    }
    
}