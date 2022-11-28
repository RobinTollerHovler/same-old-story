using System;
using System.Collections.Generic;
using System.Linq;
using Core.Movies;
using Core.Roles;
using SameOldStory.Core.Buffs;
using SameOldStory.Core.Data;
using SameOldStory.Core.Reviews;
using SameOldStory.Core.Studios;
using SameOldStory.Core.Time;
using UnityEngine;

namespace SameOldStory.Core.Movies {
    
    public class Movie : Product {

        private static Movie active;
        private MovieStage stage;
        private readonly float timeToWrite;
        private readonly float timeToProduce;
        private readonly float timeLive;
        private float timeInvested;
        private float productionCost = 10;
        private List<Role> roles = new();

        public static event Action<Movie> onNewMovie;
        public static event Action<Movie> onActiveMovieChanged;
        public static event Action<Movie> onRequestCreateMoviePoster;
        public static event Action<Movie> onMovieReviewsCollected;
        
        public event Action onDiscarding;
        public event Action onDiscarded;
        public event Action onProducing;
        public event Action onUpdated;
        public event Action onReleased;
        public event Action onCanceled;

        public Movie(string name, Genre genre) {
            Title = name;
            Genre = genre;
            timeToWrite = 2 + genre.LeastMonthsOfWorkRequired;
            timeToProduce = timeToWrite + 2 + genre.LeastMonthsOfWorkRequired;
            timeLive = timeToWrite + timeToProduce + 10;
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
        
        public Genre Genre { get; }
        public GenreReview GenreReview { get; private set; }

        public static void CreatePoster() => onRequestCreateMoviePoster?.Invoke(Active);
        
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
                    if (timeInvested >= timeLive) Cancel();
                    Studio.Current.Wallet.Earn(10 * deltaTime);
                    timeInvested += deltaTime;
                    onUpdated?.Invoke();
                    break;
            }
        }

        private void Release() {
            GenreReview = new GenreReview(this);
            Rating = new Rating(GenreReview);
            Stage = MovieStage.Released;
            onReleased?.Invoke();
            onMovieReviewsCollected?.Invoke(this);
            Studio.Current.ApplyBuff(new GenreDebuff(Genre));
        }

        private void Cancel() {
            Stage = MovieStage.Canceled;
            onCanceled?.Invoke();
        }

    }
    
}