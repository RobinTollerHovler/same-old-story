using System;
using SameOldStory.Core.Data;
using UnityEngine;

namespace SameOldStory.Core.Movies {
    
    public class Movie {

        public static event Action<Movie> onMovieBeginWriting;
        public static event Action<Movie> onActiveMovieChanged;

        public event Action onDiscarding;
        public event Action onDiscarded;
        public event Action onRelease;
        public event Action onProgressMade;

        public string Name { get; }
        public float CompletedFactor => Mathf.Clamp(completedWork / requiredWork, 0, 1);
        public bool Completed => (int)CompletedFactor == 1;

        private float requiredWork;
        private float completedWork;
        private Genre genre;
        private float minimumWork = 2;

        public Movie(string name, Genre genre) {
            Name = name;
            this.genre = genre;
            requiredWork = minimumWork + genre.LeastMonthsOfWorkRequired;
            onMovieBeginWriting?.Invoke(this);
        }

        public void Activate() => onActiveMovieChanged?.Invoke(this);

        public void WorkOn(float amount) {
            completedWork += amount;
            onProgressMade?.Invoke();
        }

        public void Discard() {
            onDiscarding?.Invoke();
            onDiscarded?.Invoke();
            onActiveMovieChanged?.Invoke(null);
        }

        public void Release() {
            Poster.Generate(this);
            onRelease?.Invoke();
            onActiveMovieChanged?.Invoke(null);
        }
        
    }
    
}