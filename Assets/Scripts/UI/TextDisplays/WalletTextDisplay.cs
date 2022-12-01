using System;
using System.Collections;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.UI.TextDisplays {
    
    public class WalletTextDisplay : TextDisplay {

        [SerializeField] private Color positiveColor;
        [SerializeField] private Color negativeColor;
        private int balance;
        
        private void OnEnable() {
            Studio.onStudioChanged += TrackStudioWallet;
            TrackStudioWallet();
        }

        private void OnDisable() {
            StopAllCoroutines();
            Studio.onStudioChanged -= TrackStudioWallet;
        }
        
        private void TrackStudioWallet() {
            if (Studio.Current == null) return;
            Studio.Current.Wallet.onBalanceChanged += UpdateDisplay;
            UpdateDisplay();
        }

        private void UpdateDisplay() {
            StopAllCoroutines();
            if (Studio.Current == null) return;
            if(isActiveAndEnabled) StartCoroutine(nameof(LerpToTargetBalance));
        }

        private IEnumerator LerpToTargetBalance() {
            int currentBalance = balance;
            int targetBalance = (int)Studio.Current.Wallet.Balance;
            float time = 0;
            float duration = .4f;
            while (time < duration) {
                int printBalance = (int)Mathf.Lerp(currentBalance, targetBalance, time / duration);
                PrintBalance(printBalance);
                time += Time.deltaTime;
                yield return null;
            }
            PrintBalance(targetBalance);
        }

        private void PrintBalance(int printBalance) {
            balance = printBalance;
            SetColor(printBalance < 0 ? negativeColor : positiveColor);
            string balanceString = printBalance > 0 ? $"${printBalance:N0}" : $"-${Math.Abs(printBalance):N0}";
            SetText($"{balanceString}");
        }
        
    }
    
}