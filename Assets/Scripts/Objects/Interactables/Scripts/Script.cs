using SameOldStory.Movies;
using TMPro;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Scripts {
    
    public class Script : InteractableObject {

        [SerializeField] private Transform node;
        
        private TextMeshProUGUI textMeshProUGUI;
        
        private Movie movie;

        public void AssignMovie(Movie movie) {
            this.movie = movie;
            Tooltip = movie.Name;
            textMeshProUGUI.text = movie.Name;
            movie.onDiscarding += RemoveScript;
        }
        
        public void SetXPosition(float position) {
            transform.localPosition = new Vector3(position, transform.localPosition.y, transform.localPosition.z);
        }

        private void Awake() => textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        
        private void OnEnable() {
            node.localScale = new Vector3(1, 1 + Random.Range(-.2f,.09f), 1);
        }

        private void RemoveScript() => Destroy(gameObject);

    }
    
}