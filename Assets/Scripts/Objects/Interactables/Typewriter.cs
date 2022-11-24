using System.Collections;
using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using UnityEngine;

namespace SameOldStory.Objects.Interactables {
    
    public class Typewriter : InteractableObject {

        [SerializeField] private TypewriterPage remainingTypewriterPage;
        [SerializeField] private TypewriterPage completedTypewriterPage;

        private Movie movie;
        
        private void Awake() {
            remainingTypewriterPage?.Deactivate();
            completedTypewriterPage?.Deactivate();
            Tooltip = $"Write script";
            ClickAction = new RequestCreateNewMovieClickAction();
        }

        private void OnEnable() {
            Movie.onActiveMovieChanged += WorkOnMovie;
        }

        private void OnDisable() {
            Movie.onActiveMovieChanged -= WorkOnMovie;
        }

        private void WorkOnMovie(Movie workOnMovie) {
            StopAllCoroutines();
            movie = workOnMovie;
            if (movie != null) {
                remainingTypewriterPage.Activate();
                completedTypewriterPage.Activate();
                StartCoroutine(nameof(WriteScript));
                StartCoroutine(nameof(UpdatePagePositions));
            } else {
                remainingTypewriterPage.Deactivate();
                completedTypewriterPage.Deactivate();
            }
        }

        private void SetPageLocations() {
            completedTypewriterPage?.SetAtFactor(1 - movie.WriteProgress);
            remainingTypewriterPage?.SetAtFactor(movie.WriteProgress);
        }
        
        private IEnumerator WriteScript() {
            while (true) {
                movie.Write(Time.deltaTime);
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