using Core.Movies;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class WhoWillPlayThisRolePanel : MonoBehaviour {

        private WindowActivationNode windowActivationNode;

        private void Awake() => windowActivationNode = GetComponentInChildren<WindowActivationNode>();

        private void OnEnable() {
            windowActivationNode?.Deactivate();
            Script.onRequestSelectActorForRole += ShowWindow;
            Script.onRoleFilled += HideWindow;
        }
        
        private void ShowWindow() {
            windowActivationNode?.Activate();
        }
        
        private void HideWindow() {
            windowActivationNode?.Deactivate();
        }
        
    }
    
}