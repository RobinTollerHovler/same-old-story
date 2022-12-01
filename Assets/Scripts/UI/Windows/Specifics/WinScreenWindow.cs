using SameOldStory.Core.Time;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class WinScreenWindow : Window {
        
        private void OnEnable() {
            Cycle.onTwentyYearsPast += DisplayEndScreen;
        }

        private void OnDisable() {
            Cycle.onTwentyYearsPast -= DisplayEndScreen;
        }
        
        private void DisplayEndScreen() {
            Cycle.Pause();
            Open();
        }

        public override void Submit() {
            Cycle.Resume();
            Close();
        }
        
    }
    
}