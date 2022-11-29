using Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public class CurrentlyWritingScriptPoster : Poster {

        private Script writingScript;
        
        private void Start() => SwapToScript(null);

        private void OnEnable() => Script.onCurrentlyWritingScriptChanged += SwapToScript;
        private void OnDisable() => Script.onCurrentlyWritingScriptChanged -= SwapToScript;

        private void SwapToScript(Script script) {
            if (writingScript != null) {
                writingScript.onProgressMade -= UpdatePoster;
            }
            AssignProduct(script);
            TogglePoster(script != null);
            if (script == null) {
                ClickAction = new NoClickAction();
            } else {
                writingScript = script;
                script.onProgressMade += UpdatePoster;
                UpdatePoster();
            }
        }

        private void UpdatePoster() {
            if (Script.CurrentlyWritingScript.WriteProgress >= 1) {
                Tooltip = $"Start production: {Script.CurrentlyWritingScript.Title}";
                ClickAction = new RequestCreatePosterForCurrentScriptClickAction();
            } else {
                Tooltip = $"Writing: {Script.CurrentlyWritingScript.Title}";
            }
        }

        private void TogglePoster(bool value) {
            PosterNode?.Toggle(value);
        }

    }
    
}