using SameOldStory.Core.Movies;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Scripts.Components.FillMasks {
    
    public class ScriptFillMask : MonoBehaviour {

        private ScriptFillMaskTopNode scriptFillMaskTopNode;
        private ScriptFillMaskBottomNode scriptFillMaskBottomNode;
        private ScriptMaskNode scriptMaskNode;
        private Movie movie;

        public void AssignToMovie(Movie movie) {
            this.movie = movie;
            movie.onProgressMade += UpdateFillMask;
        }
        
        private void Awake() {
            scriptFillMaskTopNode = GetComponentInChildren<ScriptFillMaskTopNode>();
            scriptFillMaskBottomNode = GetComponentInChildren<ScriptFillMaskBottomNode>();
            scriptMaskNode = GetComponentInChildren<ScriptMaskNode>();
        }

        private void UpdateFillMask() {
            float originPoint = scriptFillMaskBottomNode.LocalY;
            float endPoint = scriptFillMaskTopNode.LocalY;
            float targetY = originPoint + (endPoint - originPoint) * movie.CompletedFactor;
            scriptMaskNode?.SetLocalPosition(new Vector3(0,targetY,0));
        }
        
    }
    
}