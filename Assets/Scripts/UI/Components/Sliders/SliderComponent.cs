using UnityEngine;
using UnityEngine.UI;

namespace SameOldStory.UI.Components.Sliders {
    
    public class SliderComponent : MonoBehaviour {

        private Slider slider;

        public void Set(float value) {
            if (slider == null) return;
            slider.value = value;
        }
        
        private void Awake() {
            slider = GetComponent<Slider>();
            Set(0);
        }
    }
    
}