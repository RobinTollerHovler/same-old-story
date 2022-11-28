using System.Linq;
using UnityEngine;

namespace SameOldStory.UI.Windows {
    
    public abstract class Window : MonoBehaviour {

        private WindowActivationNode windowActivationNode;

        public abstract void Submit();
        
        protected virtual void OnOpen() {}
        protected virtual void OnClose() {}
        
        private void Awake() {
            windowActivationNode = GetComponentsInChildren<WindowActivationNode>(true).FirstOrDefault();
            SetUp();
        }

        public void Close() {
            OnClose();
            windowActivationNode?.Deactivate();
        }

        protected virtual void SetUp() {}
        
        protected void Open() {
            windowActivationNode?.Activate();
            OnOpen();
        }
        
    }
    
}