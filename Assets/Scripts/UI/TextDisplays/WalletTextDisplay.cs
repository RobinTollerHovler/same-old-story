using SameOldStory.Core.Studios;

namespace SameOldStory.UI.TextDisplays {
    
    public class WalletTextDisplay : TextDisplay {
        
        private void OnEnable() {
            Studio.onStudioChanged += TrackStudioWallet;
            TrackStudioWallet();
        }

        private void OnDisable() {
            Studio.onStudioChanged -= TrackStudioWallet;
        }
        
        private void TrackStudioWallet() {
            if (Studio.Current == null) return;
            Studio.Current.Wallet.onBalanceChanged += UpdateDisplay;
            UpdateDisplay();
        }

        private void UpdateDisplay() {
            if (Studio.Current == null) return;
            SetText($"${(int)Studio.Current.Wallet.Balance:N0}");
        }
        
    }
    
}