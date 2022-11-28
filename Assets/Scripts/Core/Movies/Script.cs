using System;
using Core.Roles;
using SameOldStory.Core.Time;

namespace Core.Movies {
    
    public class Script : Product {

        private static Script currentlyWritingScriptScript;
        private float writtenTime;
        
        public static event Action onRequestInitializeNewScript;
        public static event Action<Script> onCurrentlyWritingScriptChanged;
        public static event Action<Script> onRequestCreateMoviePoster;

        public event Action onRolesUpdated;
        public event Action onProgressMade;
        
        public static Script CurrentlyCreating { get; private set; }

        public static Script CurrentlyWritingScript {
            get => currentlyWritingScriptScript;
            private set {
                currentlyWritingScriptScript = value;
                onCurrentlyWritingScriptChanged?.Invoke(value);
            }
        }
        
        public float TimeToWrite { get; private set; }

        private float WrittenTime {
            get => writtenTime;
            set {
                writtenTime = value;
                onProgressMade?.Invoke();
            }
        }
        
        public float WriteProgress => WrittenTime / TimeToWrite;

        public static void ClearScript() => CurrentlyWritingScript = null;
        
        public static void Initialize() {
            CurrentlyCreating = new Script();
            onRequestInitializeNewScript?.Invoke();
            CurrentlyCreating.TimeToWrite = Cycle.MONTH;
        }

        public static void CreatePoster() {
            onRequestCreateMoviePoster?.Invoke(CurrentlyWritingScript);
        }
        
        public void Create() {
            CurrentlyWritingScript = this;
        }

        public void AddRole(Role role) {
            Roles.Add(role);
            TimeToWrite += Cycle.MONTH * 2;
            onRolesUpdated?.Invoke();
        }

        public void Write(float deltaTime) {
            WrittenTime += deltaTime;
        }
        
    }
    
}