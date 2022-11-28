using SameOldStory.Core.Time;

namespace SameOldStory.UI.TextDisplays {
    
    public class TimeTextDisplay : TextDisplay {

        private int year = 1;
        private int month = 1;
        
        private void OnEnable() => Cycle.onNewMonthTriggered += AddMonth;
        private void OnDisable() => Cycle.onNewMonthTriggered -= AddMonth;

        private void AddMonth() {
            month++;
            if (month > 12) {
                month = 1;
                year++;
            }
            SetText($"Y{year} M{month}");
        }
    }
    
}