using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes {
    
    public class SceneLoader : MonoBehaviour {
        
        [SerializeField] private string sceneToLoad;

        public void Load() {
            SceneManager.LoadScene(sceneToLoad);
        }
        
    }
    
}