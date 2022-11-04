using SameOldStory.Input.Unity;
using UnityEngine;

namespace SameOldStory.Input {
    
    public class StandardStudioInput : IStudioInput {

        private UnityInputSystem unityInputSystem;
        
        public StandardStudioInput() {
            unityInputSystem = new UnityInputSystem();
            unityInputSystem.Studio.Enable();
        }

        public Vector2 MousePosition => unityInputSystem.Studio.MousePosition.ReadValue<Vector2>();
        
    }
    
}