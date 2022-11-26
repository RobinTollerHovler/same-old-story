using System.Collections.Generic;

namespace Core.People {
    
    public class Roster {

        private HashSet<Person> persons = new();

        public Roster(int initialNumberOfPeople) {
            for (int n = 0; n < initialNumberOfPeople; n++) {
                persons.Add(new Person());
            }
        }

    }
    
}