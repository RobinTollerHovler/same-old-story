using TMPro;
using UnityEngine;

namespace SameOldStory.UI.Components {
    
    public class DropdownComponent : MonoBehaviour {

        private TMP_Dropdown dropdown;

        protected virtual void OnValueChanged(int i) {}
        
        private void Awake() {
            dropdown = GetComponent<TMP_Dropdown>();
            dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        public string Selected() {
            if (dropdown == null) return "";
            return dropdown.options[dropdown.value].text;
        }
        
        protected void SetOptions(string[] options) {
            if (dropdown == null) return;
            dropdown.options.Clear();
            foreach (string option in options) dropdown.options.Add(new TMP_Dropdown.OptionData(option));
        }

    }
    
}