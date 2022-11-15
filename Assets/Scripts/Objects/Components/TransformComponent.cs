using UnityEngine;

namespace SameOldStory.Objects.Components {
    
    public class TransformComponent : MonoBehaviour {

        public void SetLocalScale(Vector3 localScale) => transform.localScale = localScale;
        public void SetLocalPosition(Vector3 localPosition) => transform.localPosition = localPosition;
        public float LocalY => transform.localPosition.y;

    }
    
}