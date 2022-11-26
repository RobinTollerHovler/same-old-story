using UnityEngine;

namespace Core.People.Names {
    
    public abstract class FirstNameSet : ScriptableObject {

        [SerializeField] private string[] firstNames;
        [SerializeField] private SurnameSet linkedSurnameSet;

        public string RandomFirstName() => firstNames.Length == 0 ? "" : firstNames[Random.Range(0, firstNames.Length)];
        public SurnameSet LinkedSurnameSet => linkedSurnameSet;

    }
    
}