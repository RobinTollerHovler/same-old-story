using TMPro;
using UnityEngine;

namespace SameOldStory.UI.Components {
    
    public class InputFieldComponent : MonoBehaviour {

        private TMP_InputField tmpInputField;

        public string Text {
            get => tmpInputField == null ? "" : tmpInputField.text;
            private set {
                if (tmpInputField != null) tmpInputField.text = value;
            }
        }
        
        private void Awake() => tmpInputField = GetComponent<TMP_InputField>();

        public void Clear() => Text = "";

    }
    
}