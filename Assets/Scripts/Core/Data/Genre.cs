using UnityEngine;

namespace SameOldStory.Core.Data {
    
    [CreateAssetMenu(fileName = "New Genre", menuName = "Data/Genre")]
    public class Genre : UnlockableStudioData {
        
        [Header("Genre options")]
        [SerializeField] private string genreName;
        [SerializeField] private string subjectiveName;
        [SerializeField] private float attractiveness;
        [SerializeField] private int leastMonthsOfWorkRequired;
        
        public string Name => genreName;
        public string SubjectiveName => subjectiveName;
        public float Attractiveness => attractiveness;
        public int LeastMonthsOfWorkRequired => leastMonthsOfWorkRequired;

    }
    
}