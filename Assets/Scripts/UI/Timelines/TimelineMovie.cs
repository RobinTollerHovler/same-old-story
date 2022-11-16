using SameOldStory.Core.Movies;
using SameOldStory.UI.Timelines.Nodes;
using UnityEngine;

namespace SameOldStory.UI.Timelines {
    
    public class TimelineMovie : MonoBehaviour {

        private Movie movie;
        private RectTransform rectTransform;

        private CastingTimelineNode castingTimelineNode;

        public void SetVertical(float position) {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -position);
        }

        public void AttachMovie(Movie movie) {
            this.movie = movie;
            movie.onDiscarding += RemoveTimelineMovie;
        }

        public void AssignCastingLineNode(CastingTimelineNode castingTimelineNode) {
            this.castingTimelineNode = castingTimelineNode;
        }

        private void Awake() => rectTransform = GetComponent<RectTransform>();

        private void Update() {
            if (movie == null) return;
            ProgressAlongTimeline();
        }

        private void ProgressAlongTimeline() {
            float movieCompletedFactor = movie.CompletedFactor;
            rectTransform.anchoredPosition = new Vector2(movieCompletedFactor * castingTimelineNode.ScreenLocation(), rectTransform.anchoredPosition.y);
        }
        
        private void RemoveTimelineMovie() {
            DestroyImmediate(gameObject);
        }
    }
    
}