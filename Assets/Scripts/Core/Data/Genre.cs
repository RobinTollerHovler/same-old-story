using UnityEngine;

namespace SameOldStory.Core.Data {
    
    [CreateAssetMenu(fileName = "New Genre", menuName = "Data/Genre")]
    public class Genre : UnlockableStudioData {
        
        [Header("Genre options")]
        [SerializeField] private string genreName;
        [SerializeField] private string indefiniteArticle;
        [SerializeField] private string noun;
        [SerializeField] private string plural;
        [SerializeField] private float attractiveness;
        [SerializeField] private int leastMonthsOfWorkRequired;
        
        public string Name => genreName;
        public string IndefiniteArticle => indefiniteArticle;
        public string Plural => plural;
        public string Noun => noun;
        public float Attractiveness => attractiveness;
        public int LeastMonthsOfWorkRequired => leastMonthsOfWorkRequired;

    }
    
}