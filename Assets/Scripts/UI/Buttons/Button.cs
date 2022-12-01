using TMPro;
using UnityEngine;

namespace SameOldStory.UI.Buttons {
    
    public class Button : MonoBehaviour {

        private TextMeshProUGUI textMeshProUGUI;
        private UnityEngine.UI.Button button;
        
        protected void Awake() {
            button = GetComponentInChildren<UnityEngine.UI.Button>();
            button.onClick.AddListener(Click);
            textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
            SetUp();
        }

        protected virtual void SetUp() {}
        protected virtual void Click() {}

        protected void SetText(string text) => textMeshProUGUI.text = text;

        protected void SetColor(Color color) {
            button.image.color = color;
        }
        
    }
    
}