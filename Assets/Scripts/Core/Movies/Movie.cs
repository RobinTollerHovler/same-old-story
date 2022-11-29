using System;
using System.Linq;
using Core.Movies;
using Core.People;
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
            Roles = product.Roles;
            PosterSettings = product.PosterSettings;
            timeToProduce = Cycle.MonthsRequiredForWorkBase + Cycle.MonthsRequiredForWorkPerRole * Roles.Count;
            timeLive = Cycle.MonthsMoviesStayLive;
            onNewMovie?.Invoke(this);
            Cycle.onTick += Tick;
            foreach(Actor actor in Roles.Keys) actor.StartWorking();
        }

        public static void StartProduction(Script script) {
            Script.ClearScript();
            Movie newMovie = new Movie(script);
            Poster.Generate(newMovie);
            onActiveMovieChanged?.Invoke(null);
        }
        
        public Rating Rating { get; private set; }
        public bool IsLive { get; private set; }
        public Review Review { get; private set; }
        
        public void Discard() {
            onDiscarding?.Invoke();
            onActiveMovieChanged?.Invoke(null);
        }

        private float ProductionCost() {
            return Roles.Keys.Sum(actor => actor.Wage);
        }
        
        private void Tick(float deltaTime) {
            if (!IsLive) {
                if (timeInvested >= timeToProduce) Release();
                Studio.Current.Wallet.Pay(ProductionCost() * deltaTime);
                timeInvested += deltaTime;
            } else {
                if (timeInvested >= timeLive) Cancel();
                Studio.Current.Wallet.Earn(10 * deltaTime);
                timeInvested += deltaTime;
            }
            onTick?.Invoke();
        }

        private void Release() {
            foreach (Actor actor in Roles.Keys) {
                actor.IncreaseFame(1);
                actor.FinishWorking();
            }
            IsLive = true;
            timeInvested = 0;
            Review = new Review(this);
            Rating = new Rating(Review);
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