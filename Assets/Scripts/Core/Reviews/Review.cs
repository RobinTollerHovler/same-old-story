using System.Collections.Generic;
using System.Linq;
using Core.People;
using Core.Roles;
using SameOldStory.Core.Movies;
using UnityEngine;

namespace SameOldStory.Core.Reviews {
    
    public class Review {

        private string[] badGeneralReviews() {
            return new[] {
                "Bad Review 1",
                "Bad Review 2",
            };
        }

        private string[] mediocreGeneralReviews() {
            return new[] {
                "Mediocre Review 1",
                "Mediocre Review 2"
            };
        }

        private string[] goodGeneralReviews() {
            return new[] {
                "Good Review 1",
                "Good Review 2"
            };
        }

        private string[] goodRoleMatchReviews(Role role) {
            return new[] {
                $"{role.RoleTitle} is good for {movie.Genre.Plural}",
                $"Any good {movie.Genre.Noun} should contain {role.IndefiniteArticle} {role.RoleTitle}",
                $"{movie.Genre.Plural} should contain {role.Plural}",
            };
        }
        
        private string[] badRoleMatchReviews(Role role) {
            return new[] {
                $"{movie.Genre.Plural} should never contain {role.Plural}",
                $"BAD ROLE MATCH"
            };
        }
        
        private string[] goodActorMatchReviews(Actor actor) {
            return new[] {
                $"{actor.Name} is great in {movie.Genre.Plural}",
                $"GOOD ACTOR MATCH"
            };
        }
        
        private string[] badActorMatchReviews(Actor actor) {
            return new[] {
                $"{actor.Name} is horrible in {movie.Genre.Plural}",
                $"BAD ACTOR MATCH"
            };
        }
        
        private readonly Movie movie;
        private List<string> possibleReviews = new ();

        public string RandomReview => possibleReviews.Count > 0 ? possibleReviews[Random.Range(0, possibleReviews.Count)] : "I have nothing to say";
        
        public Review(Movie movie) {
            this.movie = movie;
            Score = 1 + RoleMatchScore() + ActorFameScore() + ActorMatchScore();
            possibleReviews.AddRange(Score switch {
                < 4 => badGeneralReviews(),
                < 8 => mediocreGeneralReviews(),
                _=> goodGeneralReviews()
            });
        }

        private int RoleMatchScore() {
            int roleScore = 0;
            foreach (var role in movie.Roles.Values.Where(role => role.FittingGenres.Contains(movie.Genre))) {
                roleScore += 2;
                possibleReviews.AddRange(goodRoleMatchReviews(role));
            }
            foreach (var role in movie.Roles.Values.Where(role => role.UnfittingGenres.Contains(movie.Genre))) {
                roleScore -= 2;
                possibleReviews.AddRange(badRoleMatchReviews(role));
            }
            return roleScore;
        }
        
        private int ActorMatchScore() {
            return 0;
            int actorScore = 0;
            foreach (var actor in movie.Roles.Keys.Where(a => a.GoodGenres.Contains(movie.Genre))) {
                actorScore += 2;
                possibleReviews.AddRange(goodActorMatchReviews(actor));
            }
            foreach (var actor in movie.Roles.Keys.Where(a => a.BadGenres.Contains(movie.Genre))) {
                actorScore -= 2;
                possibleReviews.AddRange(badActorMatchReviews(actor));
            }
            return actorScore;
        }

        private int ActorFameScore() {
            return movie.Roles.Keys.Sum(actor => actor.Fame / 4);
        }
        
        public float Score { get; }

    }
    
}