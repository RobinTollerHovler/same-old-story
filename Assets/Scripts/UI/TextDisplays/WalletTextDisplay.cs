using System;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.UI.TextDisplays {
    
    public class WalletTextDisplay : TextDisplay {

        [SerializeField] private Color positiveColor;
        [SerializeField] private Color negativeColor;
        
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
            int currentBalance = (int)Studio.Current.Wallet.Balance;
            SetColor(currentBalance < 0 ? negativeColor : positiveColor);
            string balance = currentBalance > 0 ? $"${currentBalance:N0}" : $"-${Math.Abs(currentBalance):N0}";
            SetText($"{balance}");
        }
        
    }
    
}