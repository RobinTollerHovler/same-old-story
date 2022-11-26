using System.Linq;
using Core.People.Names;
using UnityEngine;

namespace Core.People {
    
    public class Person {

        private static MaleFirstNameSet[] cachedMaleFirstNames;
        private static FemaleFirstNameSet[] cachedFemaleFirstNames;
        private static SurnameSet[] cachedSurnames;

        public Person() {
            if(!NameSetsLoaded) LoadNameSets();
            Gender = Random.Range(0f, 1f) switch {
                < .5f => Gender.Male,
                _ => Gender.Female
            };
            Name = Gender switch {
                Gender.Male => RandomMaleName(),
                Gender.Female => RandomFemaleName()
            };
            Face = new Face(Gender);
        }
        
        public Face Face { get; }
        public string Name { get; }
        public Gender Gender { get; }
        
        private static bool NameSetsLoaded => cachedMaleFirstNames != null && cachedFemaleFirstNames != null && cachedSurnames != null;

        private static void LoadNameSets() {
            cachedMaleFirstNames ??= Resources.LoadAll("NameSets", typeof(MaleFirstNameSet)).Cast<MaleFirstNameSet>().ToArray();
            cachedFemaleFirstNames ??= Resources.LoadAll("NameSets", typeof(FemaleFirstNameSet)).Cast<FemaleFirstNameSet>().ToArray();
            cachedSurnames ??= Resources.LoadAll("NameSets", typeof(SurnameSet)).Cast<SurnameSet>().ToArray();
        }
        
        private string RandomMaleName() => RandomName(cachedMaleFirstNames);
        private string RandomFemaleName() => RandomName(cachedFemaleFirstNames);

        private string RandomName(FirstNameSet[] firstNameSet) {
            FirstNameSet set = firstNameSet.Length == 0 ? null : firstNameSet[Random.Range(0, 1)];
            string firstName = set == null ? "" : set.RandomFirstName();
            SurnameSet surSet = set != null && set.LinkedSurnameSet == null ? cachedSurnames[Random.Range(0,1)] : set.LinkedSurnameSet;
            string surname = surSet.RandomSurname();
            return $"{firstName} {surname}";
        }

    }
    
}