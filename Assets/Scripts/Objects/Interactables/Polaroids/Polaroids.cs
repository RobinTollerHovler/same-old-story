using Core.People;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.PeopleFrames {
    
    public class Polaroids : MonoBehaviour {

        [SerializeField] private GameObject polaroidTemplate;

        void Start() {
            Studio.Current.Roster.onAddedPersonToRoster += AddPolaroid;
            InitializePolaroidsForCurrentStudio();
        }

        private void AddPolaroid(Person p) {
        }

        private void InitializePolaroidsForCurrentStudio() {
            Roster roster = Studio.Current.Roster;
            foreach (Person p in roster.People) {
                AddPolaroid(p);
            }
        }
        
    }
    
}