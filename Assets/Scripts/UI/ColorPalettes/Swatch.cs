using SameOldStory.Core.Data;
using UnityEngine;
using UnityEngine.UI;
using Button = SameOldStory.UI.Buttons.Button;

namespace UI.ColorPalettes {
    
    public class Swatch : Button {

        private Tone tone;
        
        public Tone Tone {
            get => tone;
            set {
                tone = value;
                Image i = GetComponent<Image>();
                i.color = tone.Value;
            }
        }

        protected override void Click() {
            base.Click();
            Debug.Log($"Clicked tone: {Tone.Value}");    
        }
        
    }
    
}