using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.People {
    
    public class Roster {

        public event Action onRosterUpdated;
        
        private HashSet<Actor> actors = new();

        public Roster(int initialNumberOfActors) {
            for (int n = 0; n < initialNumberOfActors; n++) {
                HireActor();
            }
        }

        public HashSet<Actor> Actors => actors;
        public int NextActorHiringCost => 500 * Actors.Count;

        public void HireActor() {
            Actor a = new Actor();
            actors.Add(a);
            onRosterUpdated?.Invoke();
        }

    }
    
}