using System;
using SameOldStory.Core.Data;

namespace SameOldStory.Core.Movies {
    
    public class Movie {
        
        private MovieStage currentStage;
        private readonly float timeToWrite;
        private readonly float timeToProduce;
        private readonly float timeToShow;
        private float investedTime;

        public static event Action<Movie> onNewMovie;
        public static event Action<Movie> onActiveMovieChanged;
        
        public event Action onDiscarding;
        public event Action onDiscarded;
        public event Action onUpdated;
        
        public Movie(string name, Genre genre) {
            Name = name;
            Genre = genre;
            timeToWrite = 2 + genre.LeastMonthsOfWorkRequired;
            currentStage = MovieStage.Writing;
            onNewMovie?.Invoke(this);
        }
        
        public string Name { get; }
        public Genre Genre { get; }

        public void Activate() => onActiveMovieChanged?.Invoke(this);
        public float WriteProgress => investedTime / timeToWrite;
        
        public void Discard() {
            onDiscarding?.Invoke();
            onDiscarded?.Invoke();
            onActiveMovieChanged?.Invoke(null);
        }

        public void Release() {
            Poster.Generate(this);
            onActiveMovieChanged?.Invoke(null);
        }

        public void Write(float amount) {
            if (currentStage != MovieStage.Writing) return;
            investedTime += amount;
            onUpdated?.Invoke();
            if (investedTime >= timeToWrite) currentStage = MovieStage.ProductionReady;
        }
    }
    
}