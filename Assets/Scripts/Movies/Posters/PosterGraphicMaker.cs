using UnityEngine;

namespace SameOldStory.Movies.Posters {
    
    public class PosterGraphicMaker : MonoBehaviour {

        [SerializeField] private GameObject poster; 
        
        private void OnEnable() => Poster.onGeneratePosterForMovie += MakePoster;
        private void OnDisable() => Poster.onGeneratePosterForMovie -= MakePoster;

        private void MakePoster(Movie movie) {
            Instantiate(poster);
        }
        
    }
    
}