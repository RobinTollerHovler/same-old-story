using System.Linq;
using Core.People;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.PeopleFrames {
    
    public class PolaroidManager : MonoBehaviour {
        
        private void Start() {
            Studio.Current.Roster.onRosterUpdated += UpdatePolaroids;
            UpdatePolaroids();
        }

        private void UpdatePolaroids() {
            Polaroid[] polaroids = GetComponentsInChildren<Polaroid>();
            foreach (Polaroid polaroid in polaroids) polaroid.Hide();
            Roster roster = Studio.Current.Roster;
            Actor[] actors = roster.Actors.ToArray();
            for (int i = 0; i < actors.Length; i++) {
                if(polaroids.Length > i) polaroids[i].Show(actors[i]);
            }
            if(polaroids.Length > actors.Length) polaroids[actors.Length].Show();
        }
        
    }
    
}