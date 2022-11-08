using System;
using UnityEngine;

namespace SameOldStory.Movies {
    
    public class Typewriter : MonoBehaviour {

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
            remainingTypewriterPage.Activate();
            completedTypewriterPage.Activate();
        }

        private void WriteMovie() => writingMovie.WorkOn(Time.deltaTime);

        private void SetPageLocations() {
            completedTypewriterPage?.SetAtFactor(1 - writingMovie.CompletedFactor);
            remainingTypewriterPage?.SetAtFactor(writingMovie.CompletedFactor);
        }

    }
    
}