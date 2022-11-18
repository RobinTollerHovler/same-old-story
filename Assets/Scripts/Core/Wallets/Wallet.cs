using System;

namespace Core.Wallets {
    
    public class Wallet {

        private float balance;

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
        }

        public bool CanAfford(float amount) => Balance >= amount;
        public void Pay(float amount) => Balance -= amount;
        public void Earn(float amount) => Balance += amount;

    }
    
}