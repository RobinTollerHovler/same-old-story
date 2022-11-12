using SameOldStory.Movies;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Scripts {
    
    public class Script : InteractableObject {

        private Movie movie;
        
        public void AssignMovie(Movie movie) {
            this.movie = movie;
            Tooltip = movie.Name;
        }
        
        public void SetXPosition(float position) {
            transform.localPosition = new Vector3(position, transform.localPosition.y, transform.localPosition.z);
        }
        
    }
    
}