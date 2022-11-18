using System;
using UnityEngine;

namespace SameOldStory.Core.Time {
    
    public class Cycle : MonoBehaviour {

        public static event Action<float> onTick;

        private void Update() => onTick?.Invoke(UnityEngine.Time.deltaTime);

    }
    
}