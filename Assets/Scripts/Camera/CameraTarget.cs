using SameOldStory.Input;
using UnityEngine;

namespace SameOldStory.Camera {
    
    public class CameraTarget : MonoBehaviour {
        
        private IStudioInput studioInput;

        private void Awake() => studioInput = new StandardStudioInput();
        
        private void LateUpdate() => MoveCameraTarget();

        private void MoveCameraTarget() {
            Vector2 pointerScreenPosition = new Vector2(
                Mathf.Clamp((studioInput.MousePosition.x - (float)Screen.width / 2) / Screen.width * 2, -1, 1),
                Mathf.Clamp((studioInput.MousePosition.y - (float)Screen.height / 2) / Screen.height * 2, -1, 1)
            );
            float feather = .5f;
            float transitionSpeed = 20;
            Vector3 targetPosition = new Vector3(
                feather * pointerScreenPosition.x,
                feather * pointerScreenPosition.y,
                transform.position.z
            );
            transform.position = Vector3.Lerp(transform.position, targetPosition, transitionSpeed * Time.deltaTime);
        }

    }
    
}