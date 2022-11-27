using System;
using System.Collections.Generic;

namespace Core.People {
    
    public class Roster {

        public event Action<Person> onAddedPersonToRoster;
        
        private HashSet<Person> persons = new();

        public Roster(int initialNumberOfPeople) {
            for (int n = 0; n < initialNumberOfPeople; n++) {
                AddPersonToRoster();
            }
        }

        public HashSet<Person> People => persons;
        
        public void AddPersonToRoster() {
            Person p = new Person();
            persons.Add(p);
            onAddedPersonToRoster?.Invoke(p);
        }

    }
    
}