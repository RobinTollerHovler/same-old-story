using UnityEngine;

namespace SameOldStory.Core.Data {
    
    [CreateAssetMenu(fileName = "New Reviewer", menuName = "Data/Reviewer")]
    public class Reviewer : StudioData {

        [SerializeField] private string reviewerName;

        public string Name => reviewerName;

    }
    
}