using System;
using SameOldStory.Movies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SameOldStory.Objects.Interactables.Scripts {
    
    public class Script : InteractableObject {

        [SerializeField] private Transform node;
        
        private Movie movie;

        public void AssignMovie(Movie movie) {
            this.movie = movie;
            Tooltip = movie.Name;
        }
        
        public void SetXPosition(float position) {
            transform.localPosition = new Vector3(position, transform.localPosition.y, transform.localPosition.z);
        }

        private void OnEnable() {
            node.localScale = new Vector3(1, 1 + Random.Range(-.2f,.09f), 1);
        }
    }
    
}