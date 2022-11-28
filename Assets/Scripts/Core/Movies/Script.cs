using System;
using Core.Roles;
using SameOldStory.Core.Time;

namespace Core.Movies {
    
    public class Script : Product {

        public static event Action onRequestCreateNewScript;

        public event Action onRolesUpdated;
        
        public static Script CurrentlyCreating { get; private set; }
        
        public float TimeToWrite { get; private set; }

        public static void Create() {
            CurrentlyCreating = new Script();
            onRequestCreateNewScript?.Invoke();
            CurrentlyCreating.TimeToWrite = Cycle.MONTH;
        }

        public void AddRole(Role role) {
            Roles.Add(role);
            TimeToWrite += Cycle.MONTH * 2;
            onRolesUpdated?.Invoke();
        }
        
    }
    
}