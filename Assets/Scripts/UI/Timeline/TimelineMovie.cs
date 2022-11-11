using UnityEngine;

namespace SameOldStory.UI.Timeline {
    
    public class TimelineMovie : MonoBehaviour {

        public void SetVertical(float position) {
            RectTransform rect = GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, -position);
        }
        
    }
    
}