using System;
using System.Linq;
using Core.People.Names;
using SameOldStory.Core.Studios;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.People {
    
    public class Actor {

        private int fame = 0;
        
        private static MaleFirstNameSet[] cachedMaleFirstNames;
        private static FemaleFirstNameSet[] cachedFemaleFirstNames;
        private static SurnameSet[] cachedSurnames;

        public event Action onStartedWorking;
        public event Action onFinishedWorking;
        
        public Actor() {
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
        public bool IsWorking { get; private set; }

        public int Wage => fame * Studio.Current.ActorWagePerFameLevel;

        public void StartWorking() {
            IsWorking = true;
            onStartedWorking?.Invoke();
        }

        public void FinishWorking() {
            IsWorking = false;
            onFinishedWorking?.Invoke();
        }

        public void IncreaseFame(int amount) => fame += amount;
        
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