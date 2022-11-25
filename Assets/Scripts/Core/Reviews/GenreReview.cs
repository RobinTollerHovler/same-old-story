using System.Linq;
using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.Core.Reviews {
    
    public class GenreReview : Review {

        private int genreFrequencyScore;
        
        public GenreReview(Movie movie) : base(movie) {
            genreFrequencyScore = CalculateFrequencyScore();
            string frequencyReaction = FrequencyReaction();
            Score += 5 + genreFrequencyScore;
            review = frequencyReaction;
        }

        private int CalculateFrequencyScore() {
            return Studio.Current.BuffManager.BuffsWithKey(movie.Genre.Name).Sum(g => g.Value);
        }

        private string FrequencyReaction() {
            return genreFrequencyScore switch {
                < -8 => $"If I have to watch any more {movie.Genre.Plural}, I'll quit my job as a reviewer",
                < -4 => $"We are so sick of {movie.Genre.Name}",
                < -2 => $"They just released {movie.Genre.Name}",
                0 => $"A good {movie.Genre.Name}",
                < 2 => $"We really needed {movie.Genre.Noun} right now!",
                _ => $"Wow, {movie.Genre.Noun} was exactly what we wanted now!"
            } + (Application.isEditor ? $" ({genreFrequencyScore})" : "");
        }

    }
    
}