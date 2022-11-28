using System;
using System.Collections.Generic;

namespace Core.People {
    
    public class Roster {

        public event Action<Actor> onAddedPersonToRoster;
        
        private HashSet<Actor> persons = new();

        public Roster(int initialNumberOfPeople) {
            for (int n = 0; n < initialNumberOfPeople; n++) {
                AddPersonToRoster();
            }
        }

        public HashSet<Actor> People => persons;
        
        public void AddPersonToRoster() {
            Actor p = new Actor();
            persons.Add(p);
            onAddedPersonToRoster?.Invoke(p);
        }

    }
    
}