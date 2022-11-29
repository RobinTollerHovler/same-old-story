using System;
using UnityEngine;

namespace SameOldStory.Core.Time {
    
    public class Cycle : MonoBehaviour {

        public static int Month { get; private set; } = 1;

        [SerializeField] private int monthDuration;
        
        private float monthProgress;
        public static event Action<float> onTick;
        public static event Action onNewMonthTriggered;

        public void Awake() {
            Month = monthDuration;
        }

        private void Update() {
            onTick?.Invoke(UnityEngine.Time.deltaTime);
            monthProgress += UnityEngine.Time.deltaTime;
            if (monthProgress >= Month) {
                monthProgress = 0;
                onNewMonthTriggered?.Invoke();
            }
        }
        
    }
    
}