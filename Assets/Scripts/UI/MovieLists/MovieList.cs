using System;
using SameOldStory.Core.Movies;
using SameOldStory.UI.Transforms;
using UnityEngine;

namespace UI.MovieLists {
    
    public class MovieList : MonoBehaviour {

        [SerializeField] private GameObject movieItemTemplate;
        

        public MovieListItem[] MovieListItems => GetComponentsInChildren<MovieListItem>();

        private void OnEnable() {
            Movie.onNewMovie += AddMovieToList;
        }

        private void OnDisable() {
            Movie.onNewMovie -= AddMovieToList;
        }

        private void AddMovieToList(Movie movie) {
            int n = MovieListItems.Length;
            Debug.Log(n + " Numbers");
            GameObject movieListItem = Instantiate(movieItemTemplate, transform);
            if (movieListItem.TryGetComponent(out RectTransformShifter rectTransformShifter)) {
                Debug.Log("setting: " + 40 * n);
                rectTransformShifter.SetAt(0, 40 * n);
            }
        }
        
    }
    
}