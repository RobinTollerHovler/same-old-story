using Core.People;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.PeopleFrames {
    
    public class Polaroids : MonoBehaviour {

        [SerializeField] private GameObject polaroidTemplate;

        void Start() {
            Studio.Current.Roster.onAddedPersonToRoster += AddPolaroid;
        }

        private void AddPolaroid(Person p) {
            
        }
        
    }
    
}