using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.UI.TextDisplays {
    
    public class WalletDisplay : TextDisplay {
        
        protected override void SetUp() {}

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
            SetText($"${Studio.Current.Wallet.Balance}");
        }
        
    }
    
}