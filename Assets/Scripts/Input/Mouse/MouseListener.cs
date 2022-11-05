using UnityEngine;

namespace SameOldStory.Input.Mouse {
    
    public class MouseListener : MonoBehaviour {

        private IStudioInput studioInput;

        private void Awake() => studioInput = new StandardStudioInput();

        private void Update() => HandleMouseInput();

        private void HandleMouseInput() {
            Ray ray = Camera.main.ScreenPointToRay(studioInput.MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("MouseEvents"))) {
                Mouse.ObjectUnderCursor = hit.transform.gameObject;
            }
        }
        
    }
    
}