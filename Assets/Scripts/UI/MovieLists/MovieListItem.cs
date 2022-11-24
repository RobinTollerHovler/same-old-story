using System;
using SameOldStory.Core;
using SameOldStory.Core.Movies;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UI.MovieLists {
    
    public class MovieListItem : MonoBehaviour, IRepresentMovie {

        private Movie movie;
        
        public event Action onRemoveItem;

        public Movie Movie {
            get => movie;
            set {
                movie = value;
                movie.onCanceled += Remove;
                movie.onDiscarding += Remove;
            }
        }

        private void Remove() {
            Destroy(gameObject);
        }

        private void OnDestroy() {
            onRemoveItem?.Invoke();
        }

    }
    
}