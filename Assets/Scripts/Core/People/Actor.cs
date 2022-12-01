using System;
using System.Collections.Generic;
using System.Linq;
using Core.People.Names;
using SameOldStory.Core.Data;
using SameOldStory.Core.Studios;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.People {
    
    public class Actor {
        
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
            foreach (Genre genre in Studio.Current.AvailableGenres) {
                if (Random.Range(0f, 1f) < .75) continue;
                if (Random.Range(0f, 1f) > .5) {
                    if(GoodGenres.Count < 5) GoodGenres.Add(genre);
                } else {
                    if(BadGenres.Count < 5) BadGenres.Add(genre);
                }
            }
        }
        
        public Face Face { get; }
        public string Name { get; }
        public Gender Gender { get; }
        public bool IsWorking { get; private set; }
        public List<Genre> GoodGenres { get; } = new();
        public List<Genre> BadGenres { get; } = new();

        public int Fame { get; private set; }
        public int Wage => (Fame * Studio.Current.ActorWagePerFameLevel) < 0 ? 0 : Fame * Studio.Current.ActorWagePerFameLevel;

        public void StartWorking() {
            IsWorking = true;
            onStartedWorking?.Invoke();
        }

        public void FinishWorking() {
            IsWorking = false;
            onFinishedWorking?.Invoke();
        }

        public void IncreaseFame(int amount) => Fame += amount;
        
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