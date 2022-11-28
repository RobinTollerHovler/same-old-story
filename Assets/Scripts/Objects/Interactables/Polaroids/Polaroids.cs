using Core.People;
using SameOldStory.Core.Studios;
using SameOldStory.Input.Mouse;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.PeopleFrames {
    
    public class Polaroids : MonoBehaviour {

        [SerializeField] private GameObject polaroidTemplate;

        void Start() {
            Studio.Current.Roster.onAddedPersonToRoster += AddPolaroid;
            InitializePolaroidsForCurrentStudio();
        }

        private void AddPolaroid(Actor p) {
        }

        private void InitializePolaroidsForCurrentStudio() {
            Roster roster = Studio.Current.Roster;
            foreach (Actor p in roster.People) {
                AddPolaroid(p);
            }
        }
        
    }
    
}