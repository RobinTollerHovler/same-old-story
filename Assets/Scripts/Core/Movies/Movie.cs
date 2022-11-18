using System;
using SameOldStory.Core.Data;

namespace SameOldStory.Core.Movies {
    
    public class Movie {

        private static Movie active;
        private MovieStage stage;
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
            Stage = MovieStage.Writing;
            onNewMovie?.Invoke(this);
        }

        public static Movie Active {
            get => active;
            private set {
                active = value;
                onActiveMovieChanged?.Invoke(value);
            }
        }
        
        public MovieStage Stage {
            get => stage;
            private set {
                stage = value;
                onUpdated?.Invoke();
            }
        }
        public string Name { get; }
        public Genre Genre { get; }

        public void Activate() => Active = this;

        public float WriteProgress => investedTime / timeToWrite;
        
        public void Discard() {
            onDiscarding?.Invoke();
            onDiscarded?.Invoke();
            onActiveMovieChanged?.Invoke(null);
        }

        public void StartProduction() {
            Poster.Generate(this);
            onActiveMovieChanged?.Invoke(null);
        }

        public void Write(float amount) {
            if (Stage != MovieStage.Writing) return;
            investedTime += amount;
            onUpdated?.Invoke();
            if (investedTime >= timeToWrite) Stage = MovieStage.ProductionReady;
        }
    }
    
}