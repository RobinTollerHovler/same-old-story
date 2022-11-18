using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using SameOldStory.Objects.Interactables.Scripts.Components;
using SameOldStory.Objects.Interactables.Scripts.Components.FillMasks;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Scripts {
    
    public class Script : InteractableObject {

        private Movie movie;
        private ScriptMovieTitleText scriptMovieTitleText;
        private ScriptFillMask scriptFillMask;

        public void AssignMovie(Movie assignMovie) {
            movie = assignMovie;
            Tooltip = movie.Name;
            scriptMovieTitleText?.Set(movie.Name);
            movie.onDiscarding += RemoveScript;
            movie.onProducing += RemoveScript;
            ClickAction = new ActivateMovieClickAction(movie);
            //scriptFillMask?.AssignToMovie(movie);
        }
        
        public void SetXPosition(float position) {
            transform.localPosition = new Vector3(position, transform.localPosition.y, transform.localPosition.z);
        }
        
        private void Awake() {
            scriptMovieTitleText = GetComponentInChildren<ScriptMovieTitleText>();
            scriptFillMask = GetComponentInChildren<ScriptFillMask>();
        }

        private void RemoveScript() {
            movie.onDiscarding -= RemoveScript;
            movie.onProducing -= RemoveScript;
            Destroy(gameObject);
        }
    }
    
}