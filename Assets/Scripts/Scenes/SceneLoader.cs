using UnityEngine;
using UnityEngine.SceneManagement;

namespace SameOldStory.Scenes {
    
    public class SceneLoader : MonoBehaviour {
        
        [SerializeField] private string sceneToLoad;

        public void Load() {
            SceneManager.LoadScene(sceneToLoad);
        }
        
    }
    
}