using System;
using UnityEngine;

namespace SameOldStory.Core.Time {
    
    public class Cycle : MonoBehaviour {

        public const float MONTH = 1;
        private float monthProgress;
        public static event Action<float> onTick;
        public static event Action onNewMonthTriggered;
        
        private void Update() {
            onTick?.Invoke(UnityEngine.Time.deltaTime);
            monthProgress += UnityEngine.Time.deltaTime;
            if (monthProgress >= MONTH) {
                monthProgress = 0;
                onNewMonthTriggered?.Invoke();
            }
        }
    }
    
}