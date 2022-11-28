using System;

namespace Core.Movies {
    
    public class Script {

        public static event Action onRequestCreateNewScript;
        
        public static void Create() => onRequestCreateNewScript?.Invoke();

    }
    
}