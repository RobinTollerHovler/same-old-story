using System;
using UnityEngine;

namespace SameOldStory.Movies {
    
    public class Movie {

        public static event Action<Movie> onMovieBeginWriting;
        public static event Action<Movie> onActiveMovieChanged;

        public event Action onDiscarding;
        public event Action onDiscarded;
        public event Action onRelease;

        public string Name { get; }
        public float CompletedFactor => Mathf.Clamp(completedWork / requiredWork, 0, 1);
        public bool Completed => (int)CompletedFactor == 1;

        private float requiredWork;
        private float completedWork;

        public Movie(string name) {
            Name = name;
            requiredWork = 30;
            onMovieBeginWriting?.Invoke(this);
        }

        public void Activate() => onActiveMovieChanged?.Invoke(this);

        public void WorkOn(float amount) => completedWork += amount;

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