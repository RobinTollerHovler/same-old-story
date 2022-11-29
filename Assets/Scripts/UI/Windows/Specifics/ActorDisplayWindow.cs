using System;
using Core.People;
using SameOldStory.Input.Mouse;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ActorDisplayWindow : MonoBehaviour {

        private WindowActivationNode windowActivationNode;

        private void Awake() => windowActivationNode = GetComponentsInChildren<WindowActivationNode>(true)[0];
        
        private void OnEnable() {
            windowActivationNode?.Deactivate();
            Mouse.objectUnderCursorChanged += DisplayActorInfo;
        }

        private void OnDisable() {
            Mouse.objectUnderCursorChanged -= DisplayActorInfo;
        }

        private void DisplayActorInfo() {
            GameObject obj = Mouse.ObjectUnderCursor;
            IRepresentActor actor = obj.GetComponentInParent<IRepresentActor>();
            if (actor == null) return;
            if(actor.Actor != null) windowActivationNode.Activate();
            else windowActivationNode.Deactivate();
        }
        
    }
    
}