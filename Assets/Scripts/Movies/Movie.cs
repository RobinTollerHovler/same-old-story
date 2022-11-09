using System;
using UnityEngine;

namespace SameOldStory.Movies {
    
    public class Movie {

        public static event Action<Movie> onMovieBeginWriting;
        
        public event Action onDiscardMovie;
        
        public string Name { get; }
        public float CompletedFactor => Mathf.Clamp(completedWork / requiredWork, 0, 1);
        public bool Completed => (int)CompletedFactor == 1;

        private float requiredWork;
        private float completedWork;

        public Movie(string name) {
            Name = name;
            requiredWork = 5;
            onMovieBeginWriting?.Invoke(this);
        }

        public void WorkOn(float amount) => completedWork += amount;

        public void Discard() {
            onDiscardMovie?.Invoke();
        }

    }
    
}