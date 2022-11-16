using System.Collections;
using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using UnityEngine;

namespace SameOldStory.Objects.Interactables {
    
    public class Typewriter : InteractableObject {

        [SerializeField] private TypewriterPage remainingTypewriterPage;
        [SerializeField] private TypewriterPage completedTypewriterPage;
        [SerializeField] private GameObject movieMakerWindow;

        private Movie movie;
        
        private void Awake() {
            remainingTypewriterPage?.Deactivate();
            completedTypewriterPage?.Deactivate();
            Tooltip = $"Write script";
            ClickAction = new ActivateGameObjectClickAction(movieMakerWindow);
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
            completedTypewriterPage?.SetAtFactor(1 - movie.CompletedFactor);
            remainingTypewriterPage?.SetAtFactor(movie.CompletedFactor);
        }
        
        private IEnumerator WriteScript() {
            while (movie is { Completed: false }) {
                movie.WorkOn(Time.deltaTime);
                yield return null;
            }
        }

        private IEnumerator UpdatePagePositions() {
            while (true) {
                while (!movie.Completed) {
                    SetPageLocations();
                    yield return new WaitForSeconds(Random.Range(.1f, .2f));
                }
                SetPageLocations();
                yield return null;
            }
        }

    }
    
}