using System;
using UnityEngine;

namespace SameOldStory.Core.Time {
    
    public class Cycle : MonoBehaviour {

        public static int Month { get; private set; } = 1;
        public static int MonthsMoviesStayLive { get; private set; } = 1;
        public static int MonthsRequiredForWorkBase { get; private set; } = 1;
        public static int MonthsRequiredForWorkPerRole { get; private set; } = 1;
        private static bool paused;
        
        [SerializeField] private int monthDuration;
        [SerializeField] private int monthsMoviesStayLive;
        [SerializeField] private int monthsRequiredForWorkBase;
        [SerializeField] private int monthsRequiredForWorkPerRole;

        private float monthProgress;
        public static event Action<float> onTick;
        public static event Action onNewMonthTriggered;

        public static void Pause() => paused = true;
        public static void Resume() => paused = false;

        public void Awake() {
            Month = monthDuration;
            MonthsMoviesStayLive = monthsMoviesStayLive;
            MonthsRequiredForWorkBase = monthsRequiredForWorkBase;
            MonthsRequiredForWorkPerRole = monthsRequiredForWorkPerRole;
        }

        private void Update() {
            if (paused) return;
            onTick?.Invoke(UnityEngine.Time.deltaTime);
            monthProgress += UnityEngine.Time.deltaTime;
            if (monthProgress >= Month) {
                monthProgress = 0;
                onNewMonthTriggered?.Invoke();
            }
        }

    }
    
}