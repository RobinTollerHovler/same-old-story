using System.Collections;
using SameOldStory.Core.Movies;
using SameOldStory.UI.Timelines.Nodes;
using UnityEngine;

namespace SameOldStory.UI.Timelines {

    public class Timeline : MonoBehaviour {

        [SerializeField] private GameObject timelineMovieTemplate;
        [SerializeField] private Transform movieNode;

        private ProductionTimelineNode productionTimelineNode;
        private LiveTimelineNode liveTimelineNode;
        private EndTimelineNode endTimelineNode;

        private RectTransform rectTransform;

        private TimelineMovie[] TimelineMovies => GetComponentsInChildren<TimelineMovie>();
        
        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
            productionTimelineNode = GetComponentInChildren<ProductionTimelineNode>();
            liveTimelineNode = GetComponentInChildren<LiveTimelineNode>();
        }

        private void OnEnable() => Movie.onNewMovie += AddMovieToTimeline;
        private void OnDisable() => Movie.onNewMovie -= AddMovieToTimeline;

        private void AddMovieToTimeline(Movie movie) {
            if (movieNode == null || timelineMovieTemplate == null) return;
            GameObject timelineMovie = Instantiate(timelineMovieTemplate, movieNode);
            if (timelineMovie.TryGetComponent(out TimelineMovie tm)) {
                tm.AttachMovie(movie);
                tm.AssignProductionTimelineNode(productionTimelineNode);
                tm.AssignLiveTimelineNode(liveTimelineNode);
            }
            movie.onDiscarded += OrganiseMovies;
            OrganiseMovies();
        }
        
        private void OrganiseMovies() {
            int n = 0;
            float height = 30;
            foreach (TimelineMovie timelineMovie in TimelineMovies) {
                timelineMovie.SetVertical(n * height);
                n++;
            }
            StopAllCoroutines();
            StartCoroutine(nameof(ResizeTimeline));
        }

        private IEnumerator ResizeTimeline() {
            float resizeSpeed = 4;
            float targetVertical = TimelineMovies.Length == 0 ? 0 : 100 + TimelineMovies.Length * 30;
            Vector2 startAnchor = rectTransform.anchoredPosition;
            Vector2 targetAncor = new Vector2(rectTransform.anchoredPosition.x, targetVertical);
            float duration = 0;
            while (duration < 1) {
                rectTransform.anchoredPosition = Vector2.Lerp(startAnchor, targetAncor, duration);
                duration += Time.deltaTime * resizeSpeed;
                yield return null;
            }
            rectTransform.anchoredPosition = targetAncor;
        }
        
    }

}