using UnityEngine;

namespace SameOldStory.UI.TextDisplays {
    
    public class VersionTextDisplay : TextDisplay {

        protected override void SetUp() => SetText($"v{Application.version}");

    }
    
}