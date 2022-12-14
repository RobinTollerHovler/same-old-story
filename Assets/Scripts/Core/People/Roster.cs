using System;
using System.Collections.Generic;
using SameOldStory.Core.Studios;

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
        public int NextActorHiringCost => (int)(Studio.Current.ActorHiringCost * (Actors.Count * 1.5f));

        public void HireActor() {
            actors.Add(new Actor());
            onRosterUpdated?.Invoke();
        }

        public void SackActor(Actor actor) {
            if (Actors.Contains(actor)) Actors.Remove(actor);
            onRosterUpdated?.Invoke();
        }

    }
    
}