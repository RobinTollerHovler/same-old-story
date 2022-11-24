using System.Linq;
using UnityEngine;

namespace SameOldStory.UI.Windows {
    
    public abstract class Window : MonoBehaviour {

        private WindowActivationNode windowActivationNode;

        public abstract void Submit();

        private void Awake() {
            windowActivationNode = GetComponentsInChildren<WindowActivationNode>(true).FirstOrDefault();
            SetUp();
        }

        public void Close() => windowActivationNode?.Deactivate();
        protected virtual void SetUp() {}
        protected void Open() => windowActivationNode?.Activate();

    }
    
}