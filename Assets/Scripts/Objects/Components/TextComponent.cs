using TMPro;
using UnityEngine;

namespace SameOldStory.Objects.Components {
    
    public class TextComponent : MonoBehaviour {
        
        private TextMeshProUGUI textMeshProUGUI;
        
        private void Awake() => textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        
        public void Set(string text) {
            if (textMeshProUGUI != null) textMeshProUGUI.text = text;
        }
        
    }
    
}