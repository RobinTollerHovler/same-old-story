using SameOldStory.Movies;
using UnityEngine;

namespace SameOldStory.Objects.Interactables {
    
    public class Typewriter : InteractableObject {

        [SerializeField] private TypewriterPage remainingTypewriterPage;
        [SerializeField] private TypewriterPage completedTypewriterPage;

        private Movie writingMovie;
        
        private void Awake() {
            remainingTypewriterPage?.Deactivate();
            completedTypewriterPage?.Deactivate();
        }

        private void Update() {
            if (writingMovie == null) return;
            WriteMovie();
            SetPageLocations();
        }

        private void OnEnable() => Movie.onMovieBeginWriting += BeginWritingMovie;
        private void OnDisable() => Movie.onMovieBeginWriting -= BeginWritingMovie;

        private void BeginWritingMovie(Movie movie) {
            writingMovie = movie;
            Tooltip = $"Writing: \"{movie.Name}\"";
            remainingTypewriterPage.Activate();
            completedTypewriterPage.Activate();
        }
        
        private void CompleteWritingMovie() => Tooltip = $"Completed: \"{writingMovie.Name}\"";

        private void WriteMovie() {
            writingMovie.WorkOn(Time.deltaTime);
            if (writingMovie.Completed) CompleteWritingMovie();
        }

        private void SetPageLocations() {
            completedTypewriterPage?.SetAtFactor(1 - writingMovie.CompletedFactor);
            remainingTypewriterPage?.SetAtFactor(writingMovie.CompletedFactor);
        }

    }
    
}