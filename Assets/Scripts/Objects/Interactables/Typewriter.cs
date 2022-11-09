using System.Collections;
using SameOldStory.Movies;
using UnityEngine;

namespace SameOldStory.Objects.Interactables {
    
    public class Typewriter : InteractableObject {

        [SerializeField] private TypewriterPage remainingTypewriterPage;
        [SerializeField] private TypewriterPage completedTypewriterPage;
        [SerializeField] private GameObject movieMakerWindow;

        private Movie writingMovie;
        
        private ClickBehaviour clickBehaviour;

        public override void MouseClick() => clickBehaviour?.Click();
        
        private void Awake() {
            remainingTypewriterPage?.Deactivate();
            completedTypewriterPage?.Deactivate();
            clickBehaviour = new ActivateGameObjectClickBehaviour(movieMakerWindow);
        }

        private void OnEnable() => Movie.onMovieBeginWriting += BeginWritingMovie;
        private void OnDisable() => Movie.onMovieBeginWriting -= BeginWritingMovie;

        private void BeginWritingMovie(Movie movie) {
            writingMovie = movie;
            Tooltip = $"Writing: \"{movie.Name}\" (Click to discard)";
            StopAllCoroutines();
            remainingTypewriterPage.Activate();
            completedTypewriterPage.Activate();
            SetPageLocations();
            StartCoroutine(nameof(WorkOnMovie));
            StartCoroutine(nameof(UpdatePagePositions));
            clickBehaviour = new DiscardMovieClickBehaviour(writingMovie);
            writingMovie.onDiscardMovie += DiscardMovie;
            writingMovie.onReleaseMovie += DiscardMovie;
        }

        private void DiscardMovie() {
            writingMovie.onDiscardMovie -= DiscardMovie;
            writingMovie.onReleaseMovie -= DiscardMovie;
            writingMovie = null;
            StopAllCoroutines();
            remainingTypewriterPage?.Deactivate();
            completedTypewriterPage?.Deactivate();
            Tooltip = $"Write script";
            clickBehaviour = new ActivateGameObjectClickBehaviour(movieMakerWindow);
        }
        
        private void CompleteWritingMovie() {
            Tooltip = $"Completed: \"{writingMovie.Name}\" (Click to start production)";
            clickBehaviour = new ReleaseMovieClickBehaviour(writingMovie);
        }

        private void SetPageLocations() {
            completedTypewriterPage?.SetAtFactor(1 - writingMovie.CompletedFactor);
            remainingTypewriterPage?.SetAtFactor(writingMovie.CompletedFactor);
        }
        
        private IEnumerator WorkOnMovie() {
            while (writingMovie is { Completed: false }) {
                writingMovie.WorkOn(Time.deltaTime);
                yield return null;
            }
            CompleteWritingMovie();
        }

        private IEnumerator UpdatePagePositions() {
            while (true) {
                while (writingMovie == null) yield return null;
                while (!writingMovie.Completed) {
                    SetPageLocations();
                    yield return new WaitForSeconds(Random.Range(.1f, .2f));
                }
                SetPageLocations();
                yield return null;
            }
        }

    }
    
}