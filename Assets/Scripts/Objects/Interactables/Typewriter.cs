using System.Collections;
using Core.Movies;
using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using UnityEngine;

namespace SameOldStory.Objects.Interactables {
    
    public class Typewriter : InteractableObject {

        [SerializeField] private TypewriterPage remainingTypewriterPage;
        [SerializeField] private TypewriterPage completedTypewriterPage;

        private Script script;
        
        private void Awake() {
            remainingTypewriterPage?.Deactivate();
            completedTypewriterPage?.Deactivate();
            Tooltip = $"Write script";
            ClickAction = new RequestCreateNewScriptClickAction();
        }

        private void OnEnable() {
            Script.onCurrentlyWritingScriptChanged += WorkOnScript;
        }

        private void OnDisable() {
            Script.onCurrentlyWritingScriptChanged -= WorkOnScript;
        }

        private void WorkOnScript(Script workOScript) {
            StopAllCoroutines();
            script = workOScript;
            if (script != null) {
                remainingTypewriterPage.Activate();
                completedTypewriterPage.Activate();
                StartCoroutine(nameof(WriteScript));
                StartCoroutine(nameof(UpdatePagePositions));
                Tooltip = $"Already working on script";
                ClickAction = new NoClickAction();
            } else {
                remainingTypewriterPage.Deactivate();
                completedTypewriterPage.Deactivate();
                Tooltip = $"Write script";
                ClickAction = new RequestCreateNewScriptClickAction();
            }
        }

        private void SetPageLocations() {
            completedTypewriterPage?.SetAtFactor(1 - Script.CurrentlyWritingScript.WriteProgress);
            remainingTypewriterPage?.SetAtFactor(Script.CurrentlyWritingScript.WriteProgress);
        }
        
        private IEnumerator WriteScript() {
            while (true) {
                Script.CurrentlyCreating?.Write(Time.deltaTime);
                yield return null;
            }
        }

        private IEnumerator UpdatePagePositions() {
            while (true) {
                SetPageLocations();
                yield return new WaitForSeconds(Random.Range(.1f, .2f));
            }
        }

    }
    
}