using Core.Movies;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ScriptMakingPanel : MonoBehaviour {
        
        private WindowActivationNode windowActivationNode;

        private void Awake() => windowActivationNode = GetComponentInChildren<WindowActivationNode>();

        private void OnEnable() {
             windowActivationNode?.Activate();
             Script.onRequestSelectActorForRole += HideWindow;
             Script.onRoleFilled += ShowWindow;
        }

        private void HideWindow() {
            windowActivationNode?.Deactivate();
        }
        
        private void ShowWindow() {
            windowActivationNode?.Activate();
        }

    }
    
}