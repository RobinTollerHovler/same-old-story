using TMPro;
using UnityEngine;

namespace SameOldStory.UI.TextDisplays {
    
    public abstract class TextDisplay : MonoBehaviour {

        private TextMeshProUGUI textMeshProUGUI;

        protected virtual void SetUp() {}

        public void SetText(string text) {
            if (textMeshProUGUI != null) textMeshProUGUI.text = text;
        }

        public void SetColor(Color color) {
            if (textMeshProUGUI != null) textMeshProUGUI.color = color;
        }
        
        private void Awake() {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            SetUp();
        }

    }
    
}