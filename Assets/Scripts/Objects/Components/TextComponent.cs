using TMPro;
using UnityEngine;

namespace SameOldStory.Objects.Components {
    
    public class TextComponent : MonoBehaviour {
        
        private TextMeshProUGUI textMeshProUGUI;
        
        private void Awake() => textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        
        public void Set(string text) {
            if (textMeshProUGUI != null) textMeshProUGUI.text = text;
        }

        public void SetColor(Color color) {
            if (textMeshProUGUI != null) textMeshProUGUI.color = color;
        }

        public void SetFont(TMP_FontAsset fontAsset) {
            if (textMeshProUGUI != null) textMeshProUGUI.font = fontAsset;
        }
        
    }
    
}