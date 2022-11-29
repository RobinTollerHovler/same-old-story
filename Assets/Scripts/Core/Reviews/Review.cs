using System.Collections.Generic;
using System.Linq;
using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace SameOldStory.Core.Reviews {
    
    public class Review {
        
        private readonly Movie movie;
        private List<string> possibleReviews = new ();

        public string RandomReview => possibleReviews.Count > 0 ? possibleReviews[Random.Range(0, possibleReviews.Count)] : "I have nothing to say";
        
        public Review(Movie movie) {
            this.movie = movie;
            Score = 1 + GenreBuffScore() + RoleMatchScore();
            possibleReviews.Add(Score switch {
                < 1 => $"This may be the worst movie Ive ever seen",
                < 3 => $"A couple of hours I'll never see again",
                < 5 => $"Totally ok movie",
                < 6 => $"Worth a rewatch",
                < 7 => $"Instant classic!",
                < 8 => $"Amazing movie!",
                < 9 => $"My new favourite!",
                _=> $"Perhaps the best movie ever produced!",
            });
        }

        public int GenreBuffScore() {
            int buffScore = Studio.Current.BuffManager.BuffsWithKey(movie.Genre.Name).Sum(g => g.Value);
            possibleReviews.Add(buffScore switch {
                < -8 => $"If I have to watch any more {movie.Genre.Plural}, I'll quit my job as a reviewer",
                < -4 => $"We are so sick of {movie.Genre.Plural}",
                _=> $"I like {movie.Genre.Plural}"
            });
            return buffScore;
        }

        public int RoleMatchScore() {
            int roleScore = 0;
            foreach (var role in movie.Roles.Values.Where(role => role.FittingGenres.Contains(movie.Genre))) {
                roleScore += 2;
                possibleReviews.Add($"{role.RoleTitle} fits well in {movie.Genre.Plural}");
            }
            foreach (var role in movie.Roles.Values.Where(role => role.UnfittingGenres.Contains(movie.Genre))) {
                roleScore -= 2;
                possibleReviews.Add($"{role.RoleTitle} has no place in {movie.Genre.Plural}");
            }
            return roleScore;
        }
        
        // public int ActorMatchScore() {
        //     int actorScore = 0;
        //     foreach (var actor in movie.Roles.Keys.Where(a => a..Contains(movie.Genre))) {
        //         roleScore += 1;
        //         possibleReviews.Add($"{role.RoleTitle} fits well in {movie.Genre.Plural}");
        //     }
        //     foreach (var role in movie.Roles.Values.Where(role => role.UnfittingGenres.Contains(movie.Genre))) {
        //         roleScore -= 1;
        //         possibleReviews.Add($"{role.RoleTitle} has no place in {movie.Genre.Plural}");
        //     }
        //     return roleScore;
        // }

        public int ActorFameScore() {
            return movie.Roles.Keys.Sum(actor => actor.Fame / 4);
        }
        
        public float Score { get; protected set; }
        

    }
    
}