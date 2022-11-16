using UnityEngine;

namespace SameOldStory.Core.Genres {
    
    [CreateAssetMenu(fileName = "New Genre", menuName = "Genre")]
    public class Genre : ScriptableObject {
        
        [SerializeField] private string genreName;
        [SerializeField] private float attractiveness;
        [SerializeField] private int leastMonthsOfWorkRequired;
        [SerializeField] private bool startAvailable;

        public string Name => genreName;
        public float Attractiveness => attractiveness;
        public int LeastMonthsOfWorkRequired => leastMonthsOfWorkRequired;
        public bool StartAvailable => startAvailable;

    }
    
}