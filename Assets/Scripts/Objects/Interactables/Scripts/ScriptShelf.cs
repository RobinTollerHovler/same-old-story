using SameOldStory.Movies;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Scripts {
    
    public class ScriptShelf : MonoBehaviour {

        [SerializeField] private GameObject scriptTemplate;
        [SerializeField] private Transform origin;
        [SerializeField] private float offset;

        private Script[] ScriptsOnShelf => GetComponentsInChildren<Script>(); 
        private void OnEnable() => Movie.onMovieBeginWriting += AddScriptToShelf;
        private void OnDisable() => Movie.onMovieBeginWriting -= AddScriptToShelf;
        
        private void AddScriptToShelf(Movie movie) {
            Instantiate(scriptTemplate, origin);
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