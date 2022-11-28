using System;

namespace Core.Movies {
    
    public class Script : Product {

        public static event Action onRequestCreateNewScript;
        
        public static Script CurrentlyCreating { get; private set; }

        public static void Create() {
            CurrentlyCreating = new Script();
            onRequestCreateNewScript?.Invoke();
        }

    }
    
}