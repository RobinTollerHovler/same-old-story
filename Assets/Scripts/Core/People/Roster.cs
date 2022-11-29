using System;
using System.Collections.Generic;

namespace Core.People {
    
    public class Roster {

        public event Action onRosterUpdated;
        
        private HashSet<Actor> actors = new();

        public Roster(int initialNumberOfPeople) {
            for (int n = 0; n < initialNumberOfPeople; n++) {
                AddActorToRoster();
            }
        }

        public HashSet<Actor> Actors => actors;
        
        public void AddActorToRoster() {
            Actor a = new Actor();
            actors.Add(a);
            onRosterUpdated?.Invoke();
        }

    }
    
}