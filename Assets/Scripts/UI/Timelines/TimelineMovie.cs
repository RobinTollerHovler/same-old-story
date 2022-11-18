using SameOldStory.Core.Movies;
using SameOldStory.UI.Timelines.Nodes;
using TMPro;
using UnityEngine;

namespace SameOldStory.UI.Timelines {
    
    public class TimelineMovie : MonoBehaviour {

        private Movie movie;
        private RectTransform rectTransform;

        private ProductionTimelineNode productionTimelineNode;

        public void SetVertical(float position) {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -position);
        }

        public void AttachMovie(Movie movie) {
            this.movie = movie;
            movie.onDiscarding += RemoveTimelineMovie;
            TextMeshProUGUI textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshProUGUI != null) textMeshProUGUI.text = movie.Name;
        }

        public void AssignProductionTimelineNode(ProductionTimelineNode productionTimelineNode) {
            this.productionTimelineNode = productionTimelineNode;
        }

        private void Awake() => rectTransform = GetComponent<RectTransform>();

        private void Update() {
            if (movie == null) return;
            ProgressAlongTimeline();
        }

        private void ProgressAlongTimeline() {
            float movieCompletedFactor = movie.WriteProgress;
            rectTransform.anchoredPosition = new Vector2(movieCompletedFactor * productionTimelineNode.ScreenLocation(), rectTransform.anchoredPosition.y);
        }
        
        private void RemoveTimelineMovie() {
            DestroyImmediate(gameObject);
        }
    }
    
}