using UnityEngine;

namespace UI.Windows.Specifics.MovieMaker.Roles {
    
    public class ActorForRoleMenu : MonoBehaviour {

        private ActorForRoleMenuNode actorForRoleMenuNode;

        private void Awake() => actorForRoleMenuNode = GetComponentInChildren<ActorForRoleMenuNode>();
        
        public void Open() {
            
        }
        
    }
    
}