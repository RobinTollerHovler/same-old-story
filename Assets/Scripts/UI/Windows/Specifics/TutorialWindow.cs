using System;
using SameOldStory.Core.Time;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class TutorialWindow : Window {
        
        private void OnEnable() {
            Cycle.Pause();
        }

        protected override void SetUp() {
            base.SetUp();
            Open();
        }

        public override void Submit() {
            Close();
            Cycle.Resume();
        }
        
    }
    
}