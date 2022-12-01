using Core.Movies;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class SubmitScriptButton : SubmitWindowButton {

        private void Update() {
            Script creating = Script.CurrentlyCreating;
            if (creating == null) return;
            if (string.IsNullOrEmpty(creating.Title)) {
                ToggleEnabled(false);
                return;
            }
            if (creating.Roles.Count == 0) {
                ToggleEnabled(false);
                return;
            }
            ToggleEnabled(true);
        }
        
    }
    
}