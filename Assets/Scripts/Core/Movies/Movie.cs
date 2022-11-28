using System;
using Core.Movies;
using SameOldStory.Core.Buffs;
using SameOldStory.Core.Reviews;
using SameOldStory.Core.Studios;
using SameOldStory.Core.Time;

namespace SameOldStory.Core.Movies {
    
    public class Movie : Product {
        
        private readonly float timeToProduce;
        private readonly float timeLive;
        private float timeInvested;
        
        public static event Action<Movie> onNewMovie;
        public static event Action<Movie> onActiveMovieChanged;
        public static event Action<Movie> onMovieReviewsCollected;
        public static event Action<Movie> onRequestStartProduceMovie;
        
        public event Action onDiscarding;
        public event Action onCanceled;
        public event Action onReleased;
        public event Action onTick;

        private Movie(Product product) {
            Title = product.Title;
            Genre = product.Genre;
            timeToProduce = Cycle.MONTH * 6;
            timeLive = Cycle.MONTH * 12;
            onNewMovie?.Invoke(this);
            Cycle.onTick += Tick;
        }

        public static void StartProduction(Script script) {
            Script.ClearScript();
            Movie newMovie = new Movie(script);
            Poster.Generate(newMovie);
            onActiveMovieChanged?.Invoke(null);
        }
        
        public Rating Rating { get; private set; }
        public bool IsLive { get; private set; }
        public GenreReview GenreReview { get; private set; }
        
        public void Discard() {
            onDiscarding?.Invoke();
            onActiveMovieChanged?.Invoke(null);
        }

        private float ProductionCost() {
            return 5;
        }
        
        private void Tick(float deltaTime) {
            if (!IsLive) {
                if (timeInvested >= timeToProduce) Release();
                if (Studio.Current.Wallet.CanAfford(ProductionCost() * deltaTime)) {
                    Studio.Current.Wallet.Pay(ProductionCost() * deltaTime);
                    timeInvested += deltaTime;
                }
            } else {
                if (timeInvested >= timeLive) Cancel();
                Studio.Current.Wallet.Earn(10 * deltaTime);
                timeInvested += deltaTime;
            }
            onTick?.Invoke();
        }

        private void Release() {
            IsLive = true;
            timeInvested = 0;
            GenreReview = new GenreReview(this);
            Rating = new Rating(GenreReview);
            onReleased?.Invoke();
            onMovieReviewsCollected?.Invoke(this);
            Studio.Current.ApplyBuff(new GenreDebuff(Genre));
        }

        private void Cancel() {
            onCanceled?.Invoke();
            Cycle.onTick -= Tick;
        }

    }
    
}