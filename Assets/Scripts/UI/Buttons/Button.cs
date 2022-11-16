using TMPro;
using UnityEngine;

namespace SameOldStory.UI.Buttons {
    
    public class Button : MonoBehaviour {

        private TextMeshProUGUI textMeshProUGUI;
        
        protected void Awake() {
            UnityEngine.UI.Button button = GetComponentInChildren<UnityEngine.UI.Button>();
            button.onClick.AddListener(Click);
            textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected virtual void Click() {}

        protected void SetText(string text) => textMeshProUGUI.text = text;
        
    }
    
}