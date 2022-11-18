using SameOldStory.Core.Movies;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Scripts {
    
    public class ScriptShelf : MonoBehaviour {

        [SerializeField] private GameObject scriptTemplate;
        [SerializeField] private Transform origin;
        [SerializeField] private float offset;

        private Script[] ScriptsOnShelf => GetComponentsInChildren<Script>(); 
        private void OnEnable() => Movie.onNewMovie += AddScriptToShelf;
        private void OnDisable() => Movie.onNewMovie -= AddScriptToShelf;
        
        private void AddScriptToShelf(Movie movie) {
            movie.onDiscarded += ReorderScripts;
            GameObject newScript = Instantiate(scriptTemplate, origin);
            if(newScript.TryGetComponent(out Script s)) {s.AssignMovie(movie);}
            ReorderScripts();
        }

        private void ReorderScripts() {
            int n = 0;
            foreach (Script script in ScriptsOnShelf) {
                script.SetXPosition(n * offset);
                n++;
            }
        }
        
    }
    
}