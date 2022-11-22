using SameOldStory.Core.Movies;
using UnityEngine;

namespace Characters {

    public class Manus : MonoBehaviour {

        private ManusArm[] arms;

        private void Awake() {
            arms = GetComponentsInChildren<ManusArm>();
        }

        private void OnEnable() => Movie.onActiveMovieChanged += ActiveMovieChanged;
        private void OnDisable() => Movie.onActiveMovieChanged -= ActiveMovieChanged;

        private void ActiveMovieChanged(Movie movie) {
            if (movie == null || movie.WriteProgress >= 1) {
                foreach(ManusArm arm in arms) arm.EndTyping();
            } else {
                foreach(ManusArm arm in arms) arm.BeginTyping();
            }
        }

    }
    
}