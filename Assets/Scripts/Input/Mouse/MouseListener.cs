using UnityEngine;

namespace SameOldStory.Input.Mouse {
    
    public class MouseListener : MonoBehaviour {

        private IStudioInput studioInput;

        private void Awake() => studioInput = new StandardStudioInput();

        private void OnEnable() => studioInput.onMouseClick += MouseClick;
        private void OnDisable() => studioInput.onMouseClick -= MouseClick;

        private void Update() => HandleMouseInput();
        
        private void HandleMouseInput() {
            Ray ray = Camera.main.ScreenPointToRay(studioInput.MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("MouseEvents"))) {
                Mouse.ObjectUnderCursor = hit.transform.gameObject;
            }
            Mouse.Position = studioInput.MousePosition;
        }
        
        private void MouseClick() {
            Mouse.ObjectUnderCursor?.GetComponentInParent<IReactToMouseClick>()?.MouseClick();
        }
        
    }
    
}