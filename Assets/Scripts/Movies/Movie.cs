using System;
using UnityEngine;

namespace SameOldStory.Movies {
    
    public class Movie {

        public static event Action<Movie> onMovieBeginWriting;
        public static Movie CurrentlyWritingMovie { get; private set; }
        
        public string Name { get; private set; }
        public float CompletedFactor => Mathf.Clamp(completedWork / requiredWork, 0, 1);

        private float requiredWork;
        private float completedWork;

        public Movie(string name) {
            Name = name;
            requiredWork = 5;
            CurrentlyWritingMovie = this;
            onMovieBeginWriting?.Invoke(this);
        }

        public void WorkOn(float amount) => completedWork += amount;

    }
    
}