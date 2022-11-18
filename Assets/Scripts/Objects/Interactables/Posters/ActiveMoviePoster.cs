using System;
using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public class ActiveMoviePoster : Poster {

        [SerializeField] private GameObject posterWindow;
        
        private void Start() => SwapToMovie(null);

        private void OnEnable() => Movie.onActiveMovieChanged += SwapToMovie;
        private void OnDisable() => Movie.onActiveMovieChanged -= SwapToMovie;

        private void SwapToMovie(Movie movie) {
            if (this.movie != null) this.movie.onUpdated -= UpdatePoster;
            AssignMovie(movie);
            TogglePoster(movie != null);
            if (movie == null) {
                ClickAction = new NoClickAction();
            } else {
                movie.onUpdated += UpdatePoster;
                UpdatePoster();
            }
        }

        private void UpdatePoster() {
            switch (movie.Stage) {
                case MovieStage.Writing:
                    Tooltip = $"Writing: {movie.Name} ({(int)(movie.WriteProgress * 100)}%)";
                    break;
                case MovieStage.ProductionReady:
                    Tooltip = $"Start production: {movie.Name}";
                    ClickAction = new ActivateGameObjectClickAction(posterWindow);
                    break;
            }
        }

        private void TogglePoster(bool value) {
            PosterNode?.Toggle(value);
        }
        
    }
    
}