using System;
using Core.Roles;

namespace Core.Movies {
    
    public class Script : Product {

        public static event Action onRequestCreateNewScript;

        public event Action onRolesUpdated;
        
        public static Script CurrentlyCreating { get; private set; }

        public static void Create() {
            CurrentlyCreating = new Script();
            onRequestCreateNewScript?.Invoke();
        }

        public void AddRole(Role role) {
            Roles.Add(role);
            onRolesUpdated?.Invoke();
        }
    }
    
}