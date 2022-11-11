using SameOldStory.Movies;
using UnityEngine;

namespace SameOldStory.UI.Timeline {

    public class Timeline : MonoBehaviour {

        [SerializeField] private GameObject timelineMovieTemplate;
        [SerializeField] private Transform movieNode;

        private RectTransform rectTransform;
        
        private void Awake() => rectTransform = GetComponent<RectTransform>();

        private void Update() {
            //rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(0, 500), Time.deltaTime);
        }

        private void OnEnable() => Movie.onMovieBeginWriting += AddMovieToTimeline;
        private void OnDisable() => Movie.onMovieBeginWriting -= AddMovieToTimeline;

        private void AddMovieToTimeline(Movie movie) {
            if (movieNode == null || timelineMovieTemplate == null) return;
            Instantiate(timelineMovieTemplate, movieNode);
            OrganiseMovies();
        }

        private void OrganiseMovies() {
            int n = 0;
            float height = 35;
            foreach (TimelineMovie timelineMovie in GetComponentsInChildren<TimelineMovie>()) {
                timelineMovie.SetVertical(n * height);
                n++;
            }
        }
        
    }

}