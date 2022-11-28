using System;
using UnityEngine;

namespace SameOldStory.Core.Time {
    
    public class Cycle : MonoBehaviour {

        public const float MONTH = 8;
        
        public static event Action<float> onTick;

        private void Update() => onTick?.Invoke(UnityEngine.Time.deltaTime);

    }
    
}