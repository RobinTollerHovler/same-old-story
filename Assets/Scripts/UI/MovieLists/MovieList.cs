using SameOldStory.Core;
using SameOldStory.Core.Movies;
using SameOldStory.UI.Transforms;
using UnityEngine;

namespace UI.MovieLists {
    
    public class MovieList : MonoBehaviour {

        [SerializeField] private GameObject movieItemTemplate;
        

        private MovieListItem[] MovieListItems => GetComponentsInChildren<MovieListItem>();

        private void OnEnable() {
            Movie.onNewMovie += AddMovieToList;
        }

        private void OnDisable() {
            Movie.onNewMovie -= AddMovieToList;
        }

        private void AddMovieToList(Movie movie) {
            int n = MovieListItems.Length;
            GameObject movieListItem = Instantiate(movieItemTemplate, transform);
            if (movieListItem.TryGetComponent(out RectTransformShifter rectTransformShifter)) {
                rectTransformShifter.SetAt(0, -70 * n);
            }

            if (movieListItem.TryGetComponent(out IRepresentMovie representMovie)) representMovie.Movie = movie;

        }
        
    }
    
}