using UnityEngine;

namespace Glow.Persistence {
    
    public class PersistentObject : MonoBehaviour {

        private static PersistentObject instance;
        
        private void Awake() {
            if (instance == null) {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }
        
    }
    
}