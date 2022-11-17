using System;

namespace Core.Wallets {
    
    public class Wallet {

        private int balance;

        public event Action onBalanceChanged;

        public int Balance {
            get => balance;
            private set {
                balance = value;
                onBalanceChanged?.Invoke();
            }
        }
        
        public Wallet(int initialBalance) {
            Balance = initialBalance;
        }
        
    }
    
}