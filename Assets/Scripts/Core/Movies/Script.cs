using System;
using Core.People;
using Core.Roles;
using SameOldStory.Core.Time;
using UnityEngine;

namespace Core.Movies {
    
    public class Script : Product {

        private static Script currentlyWritingScriptScript;
        private float writtenTime;
        private Role nonCastedRole;

        public static event Action onRequestInitializeNewScript;
        public static event Action<Script> onCurrentlyWritingScriptChanged;
        public static event Action<Script> onRequestCreateMoviePoster;
        public static event Action onRequestSelectActorForRole;
        public static event Action onRoleFilled;
        
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

        private float TimeToWrite => Cycle.MonthsRequiredForWorkBase + Cycle.MonthsRequiredForWorkPerRole * Roles.Count;

        private float WrittenTime {
            get => writtenTime;
            set {
                writtenTime = value;
                onProgressMade?.Invoke();
            }
        }
        
        public float WriteProgress => Mathf.Clamp(WrittenTime / TimeToWrite, 0, 1);

        public static void ClearScript() {
            if (CurrentlyCreating != null) {
                foreach (Actor actor in CurrentlyCreating.Roles.Keys) {
                    actor.FinishWorking();
                }
            }
            CurrentlyWritingScript = null;
        }

        public static void Initialize() {
            CurrentlyCreating = new Script();
            onRequestInitializeNewScript?.Invoke();
        }

        public static void CreatePoster() {
            onRequestCreateMoviePoster?.Invoke(CurrentlyWritingScript);
        }
        
        public void Create() {
            CurrentlyWritingScript = this;
        }

        public void AddRole(Role role) {
            nonCastedRole = role;
            onRequestSelectActorForRole?.Invoke();
        }

        public void AddActorToUncastedRole(Actor actor) {
            if (Roles.ContainsKey(actor)) return;
            if (nonCastedRole != null) {
                Roles.Add(actor, nonCastedRole);
                actor.StartWorking();
                nonCastedRole = null;
                onRoleFilled?.Invoke();
            }
            onRolesUpdated?.Invoke();
        }

        public void Write(float deltaTime) {
            WrittenTime += deltaTime;
        }
        
    }
    
}