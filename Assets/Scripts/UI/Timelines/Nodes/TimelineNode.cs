using UnityEngine;

namespace SameOldStory.UI.Timelines.Nodes {
    
    public abstract class TimelineNode : MonoBehaviour {
        
        public float ScreenLocation() {
            if (TryGetComponent(out RectTransform rect)) {
                return rect.anchoredPosition.x;
            }
            return 0;
        }
        
    }
    
}