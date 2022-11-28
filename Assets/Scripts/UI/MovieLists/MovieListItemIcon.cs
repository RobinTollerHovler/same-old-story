using SameOldStory.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MovieLists {
    
    public class MovieListItemIcon : MonoBehaviour {

        [SerializeField] private Sprite producingIcon;
        [SerializeField] private Sprite liveIcon;
        
        private IRepresentMovie representMovie;
        private Image image;

        private void Awake() => image = GetComponent<Image>();
        
        private void Start() {
            representMovie = GetComponentInParent<IRepresentMovie>();
            if (representMovie != null) representMovie.Movie.onTick += SetNewIcon;
        }

        private void SetNewIcon() {
            if (image == null) return;
            image.sprite = representMovie.Movie.IsLive ? liveIcon : producingIcon;
        }
        
    }
    
}