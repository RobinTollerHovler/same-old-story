using System;
using SameOldStory.Core.Movies;
using UnityEngine;

namespace UI.MovieLists {
    
    public class MovieList : MonoBehaviour {

        [SerializeField] private GameObject movieItemTemplate;

        private void OnEnable() {
            Movie.onNewMovie += AddMovieToList;
        }

        private void OnDisable() {
            Movie.onNewMovie -= AddMovieToList;
        }

        private void AddMovieToList(Movie movie) {
            Instantiate(movieItemTemplate, transform);
        }
        
    }
    
}