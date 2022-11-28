using UnityEngine;

namespace UI.Windows.Specifics.MovieMaker.Roles {
    
    public class ActorMenu : MonoBehaviour {

        private ActorMenuNode actorMenuNode;

        private void Awake() => actorMenuNode = GetComponentInChildren<ActorMenuNode>();
        
        public void Open() {
            
        }
        
    }
    
}