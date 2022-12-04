using SameOldStory.Core.Time;

namespace SameOldStory.UI.TextDisplays {
    
    public class TimeTextDisplay : TextDisplay {

        private int year = 1;
        private int month = 1;
        
        private void OnEnable() {
            SetText($"Jan Year: 1");
            Cycle.onNewMonthTriggered += AddMonth;
        }

        private void OnDisable() => Cycle.onNewMonthTriggered -= AddMonth;

        private void AddMonth() {
            month++;
            if (month > 12) {
                month = 1;
                year++;
                if(year == 20) Cycle.TwentyYearsPast();
            }
            string monthName = month switch {
                1 => "Jan",
                2 => "Feb",
                3 => "March",
                4 => "April",
                5 => "May",
                6 => "June",
                7 => "July",
                8 => "Aug",
                9 => "Sep",
                10 => "Oct",
                11 => "Nov",
                12 => "Dec",
                _ => ""
            };
            SetText($"{monthName} Year: {year}");
        }
    }
    
}