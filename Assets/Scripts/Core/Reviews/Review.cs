using System.Collections.Generic;
using System.Linq;
using Core.People;
using Core.Roles;
using SameOldStory.Core.Movies;
using UnityEngine;

namespace SameOldStory.Core.Reviews
{

    public class Review
    {

        private string[] badGeneralReviews()
        {
            return new[] {
                "This sucks",
                "I coud've made this movie",
                "Who greenlit this script?",
                "I'd rather watch moss grow than this",
                "This is truly the end of cinema",
                "Amateurish, ill-conceived, bad",
                "Don't waste 2hrs of your life watching this",
            };
        }

        private string[] mediocreGeneralReviews()
        {
            return new[] {
                "Aside from slow pacing, a decent flick",
                "A lack-luster execution of a great concept",
                "All movies don't have to be Citizen Kane",
                "At least it's not boring",
                "I'm not gonna say I hate it, but I don't love it either",
                "Fine, but there's better things to watch",
                "This film-maker might evetually make something interesting",
            };
        }

        private string[] goodGeneralReviews()
        {
            return new[] {
                "Incredible, a must-watch!",
                "Hold on to your pants, because cinema is saved!",
                "This movie puts everything else released this year to shame",
                "I don't even usually like this genre!",
                "Perfect cast, perfect script, perfect movie",
                "This movie is the GOAT",
                "I'll definitely see this many more times",
            };
        }

        private string[] goodRoleMatchReviews(Role role)
        {
            return new[] {
                $"{role.RoleTitle} is good in {movie.Genre.Plural}",
                $"Any good {movie.Genre.Noun} should contain {role.IndefiniteArticle} {role.RoleTitle}",
                $"{movie.Genre.Plural} should contain {role.Plural}",
                $"What would {movie.Genre.Plural} be without {role.Plural}?",
                $"You wouldn't believe how well {role.Plural} fit into {movie.Genre.Plural}",
                $"{role.Plural} really makes {movie.Genre.Plural}",
                $"To have {role.Plural} in {movie.Genre.Plural} was a stroke of genius!",
            };
        }

        private string[] badRoleMatchReviews(Role role)
        {
            return new[] {
                $"{movie.Genre.Plural} should never contain {role.Plural}",
                $"BAD ROLE MATCH"
            };
        }

        private string[] goodActorMatchReviews(Actor actor)
        {
            return new[] {
                $"{actor.Name} is great in {movie.Genre.Plural}",
                $"GOOD ACTOR MATCH"
            };
        }

        private string[] badActorMatchReviews(Actor actor)
        {
            return new[] {
                $"{actor.Name} is horrible in {movie.Genre.Plural}",
                $"BAD ACTOR MATCH"
            };
        }

        private readonly Movie movie;
        private List<string> possibleReviews = new();

        public string RandomReview => possibleReviews.Count > 0 ? possibleReviews[Random.Range(0, possibleReviews.Count)] : "I have nothing to say";

        public Review(Movie movie)
        {
            this.movie = movie;
            Score = 1 + RoleMatchScore() + ActorFameScore() + ActorMatchScore();
            possibleReviews.AddRange(Score switch
            {
                < 4 => badGeneralReviews(),
                < 8 => mediocreGeneralReviews(),
                _ => goodGeneralReviews()
            });
        }

        private int RoleMatchScore()
        {
            int roleScore = 0;
            foreach (var role in movie.Roles.Values.Where(role => role.FittingGenres.Contains(movie.Genre)))
            {
                roleScore += 2;
                possibleReviews.AddRange(goodRoleMatchReviews(role));
            }
            foreach (var role in movie.Roles.Values.Where(role => role.UnfittingGenres.Contains(movie.Genre)))
            {
                roleScore -= 2;
                possibleReviews.AddRange(badRoleMatchReviews(role));
            }
            return roleScore;
        }

        private int ActorMatchScore()
        {
            return 0;
            int actorScore = 0;
            foreach (var actor in movie.Roles.Keys.Where(a => a.GoodGenres.Contains(movie.Genre)))
            {
                actorScore += 2;
                possibleReviews.AddRange(goodActorMatchReviews(actor));
            }
            foreach (var actor in movie.Roles.Keys.Where(a => a.BadGenres.Contains(movie.Genre)))
            {
                actorScore -= 2;
                possibleReviews.AddRange(badActorMatchReviews(actor));
            }
            return actorScore;
        }

        private int ActorFameScore()
        {
            return movie.Roles.Keys.Sum(actor => actor.Fame / 4);
        }

        public float Score { get; }

    }

}