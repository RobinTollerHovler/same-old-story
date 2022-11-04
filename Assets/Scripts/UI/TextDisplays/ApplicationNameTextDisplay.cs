using UnityEngine;

namespace SameOldStory.UI.TextDisplays {
    
    public class ApplicationNameTextDisplay : TextDisplay {

        protected override void SetUp() => SetText($"{Application.productName}");

    }
    
}