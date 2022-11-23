using SameOldStory.Core;

namespace SameOldStory.UI.Components.Sliders {
    
    public class MovieRating : SliderComponent {

        private IRepresentMovie representMovie;
        
        private void Start() {
            representMovie = GetComponentInParent<IRepresentMovie>();
            representMovie.Movie.onReleased += UpdateStars;
        }

        private void OnDisable() {
            representMovie.Movie.onReleased -= UpdateStars;
        }

        private void UpdateStars() {
            if (representMovie?.Movie.Rating == null) return;
            representMovie.Movie.onReleased += UpdateStars;
            Set((float)representMovie.Movie.Rating.Stars() / 5);
        }
    }
    
}