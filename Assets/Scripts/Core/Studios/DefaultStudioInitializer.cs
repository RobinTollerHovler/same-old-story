using UnityEngine;

namespace SameOldStory.Core.Studios {
    
    public class DefaultStudioInitializer : MonoBehaviour {

        [SerializeField] private int actorWagePerFameLevel = 0;
        [SerializeField] private int payoutPerScore;
        [SerializeField] private int actorHiringCost;
        
        private void Awake() => Studio.InitializeNewStudio(
            actorWagePerFameLevel, 
            payoutPerScore,
            actorHiringCost
        );
        
    }
    
}