using System;
using SameOldStory.Core.Time;

namespace Core.Wallets {
    
    public class Wallet {

        private float balance;
        private float temporaryBalance;
        
        public event Action onBalanceChanged;

        public float Balance {
            get => balance;
            private set {
                balance = value;
                onBalanceChanged?.Invoke();
            }
        }
        
        public Wallet(int initialBalance) {
            Balance = initialBalance;
            Cycle.onNewMonthTriggered += Payday;
        }

        public bool CanAfford(float amount) => Balance >= amount;
        
        public void Pay(float amount) => temporaryBalance -= amount;
        public void Buy(float amount) => Balance -= amount;
        public void Earn(float amount) => temporaryBalance += amount;

        private void Payday() {
            Balance += temporaryBalance;
            temporaryBalance = 0;
        }

    }
    
}