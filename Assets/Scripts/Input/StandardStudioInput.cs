using System;
using SameOldStory.Input.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SameOldStory.Input {
    
    public class StandardStudioInput : IStudioInput {
        
        private UnityInputSystem unityInputSystem;
        
        public StandardStudioInput() {
            unityInputSystem = new UnityInputSystem();
            unityInputSystem.Studio.Enable();
            unityInputSystem.Studio.MouseClick.started += MouseClick;
        }

        ~StandardStudioInput() {
            unityInputSystem.Studio.MouseClick.started -= MouseClick;
        }
        
        public event Action onMouseClick;

        public Vector2 MousePosition => unityInputSystem.Studio.MousePosition.ReadValue<Vector2>();
        private void MouseClick(InputAction.CallbackContext obj) => onMouseClick?.Invoke();

    }
    
}