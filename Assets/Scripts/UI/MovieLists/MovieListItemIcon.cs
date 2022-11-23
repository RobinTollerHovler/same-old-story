using SameOldStory.Core;
using SameOldStory.Core.Movies;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MovieLists {
    
    public class MovieListItemIcon : MonoBehaviour {

        [SerializeField] private Sprite writingIcon;
        [SerializeField] private Sprite producingIcon;
        [SerializeField] private Sprite liveIcon;
        
        private IRepresentMovie representMovie;
        private Image image;

        private void Awake() => image = GetComponent<Image>();
        
        private void Start() {
            representMovie = GetComponentInParent<IRepresentMovie>();
            if (representMovie != null) representMovie.Movie.onUpdated += SetNewIcon;
        }

        private void SetNewIcon() {
            if (image == null) return;
            image.sprite = representMovie.Movie.Stage switch {
                MovieStage.Writing => writingIcon,
                MovieStage.Producing => producingIcon,
                MovieStage.Released  => liveIcon,
                _ => writingIcon
            };
        }
        
    }
    
}