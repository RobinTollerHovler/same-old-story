using System;
using Core.Movies;
using SameOldStory.Core.Buffs;
using SameOldStory.Core.Data;
using SameOldStory.Core.Studios;
using SameOldStory.Core.Time;

namespace SameOldStory.Core.Movies {
    
    public class Movie {

        private int score = 10;
        private static Movie active;
        private MovieStage stage;
        private readonly float timeToWrite;
        private readonly float timeToProduce;
        private readonly float timeLive;
        private float timeInvested;
        private float productionCost = 10;

        public static event Action<Movie> onNewMovie;
        public static event Action<Movie> onActiveMovieChanged;

        public event Action onDiscarding;
        public event Action onDiscarded;
        public event Action onProducing;
        public event Action onUpdated;
        public event Action onReleased;
        
        public Movie(string name, Genre genre) {
            Name = name;
            Genre = genre;
            timeToWrite = 2 + genre.LeastMonthsOfWorkRequired;
            timeToProduce = timeToWrite + 2 + genre.LeastMonthsOfWorkRequired;
            timeLive = timeToWrite + timeToProduce + 60;
            Stage = MovieStage.Writing;
            onNewMovie?.Invoke(this);
            Cycle.onTick += Tick;
        }
        
        ~Movie() {
            Cycle.onTick -= Tick;
        }

        public Rating Rating { get; private set; }
        
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

        public float WriteProgress => timeInvested / timeToWrite;
        public float ProductionProgress => (timeInvested - timeToWrite) / timeToProduce;
        
        public void Discard() {
            onDiscarding?.Invoke();
            onDiscarded?.Invoke();
            onActiveMovieChanged?.Invoke(null);
        }

        public void StartProduction() {
            Poster.Generate(this);
            Stage = MovieStage.Producing;
            onProducing?.Invoke();
            onActiveMovieChanged?.Invoke(null);
        }

        public void Write(float amount) {
            if (Stage != MovieStage.Writing) return;
            timeInvested += amount;
            onUpdated?.Invoke();
            if (timeInvested >= timeToWrite) Stage = MovieStage.ProductionReady;
        }

        private void Tick(float deltaTime) {
            switch (Stage) {
                case MovieStage.Producing:
                    if (timeInvested >= timeToProduce) Release();
                    if (Studio.Current.Wallet.CanAfford(productionCost * deltaTime)) {
                        Studio.Current.Wallet.Pay(productionCost * deltaTime);
                        timeInvested += deltaTime;
                    }
                    onUpdated?.Invoke();
                    break;
                case MovieStage.Released:
                    if (timeInvested >= timeLive) Stage = MovieStage.Canceled;
                    Studio.Current.Wallet.Earn(10 * deltaTime);
                    onUpdated?.Invoke();
                    break;
            }
        }

        private void Release() {
            score = CalculateScore();
            Rating = new Rating(score);
            Stage = MovieStage.Released;
            onReleased?.Invoke();
            Studio.Current.ApplyBuff(new GenreDebuff(Genre));
        }

        private int CalculateScore() {
            int s = 2;
            foreach (Buff b in Studio.Current.BuffManager.BuffsWithKey(Genre.Name)) {
                s += b.Value;
            }
            return s;
        }
        
    }
    
}