using UnityEngine;

namespace Core.People.Names {
    
    [CreateAssetMenu(fileName = "New Surname Set", menuName = "Data/Name Set/Surnames")]
    public class SurnameSet : ScriptableObject {

        [SerializeField] private string[] surnames;

        public string RandomSurname() => surnames.Length == 0 ? "" : surnames[Random.Range(0, surnames.Length)];
        
    }
    
}