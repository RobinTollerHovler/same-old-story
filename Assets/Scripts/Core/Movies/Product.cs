using System.Collections.Generic;
using Core.People;
using Core.Roles;
using SameOldStory.Core.Data;

namespace Core.Movies {
    
    public abstract class Product {
        
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Dictionary<Actor, Role> Roles { get; protected set; } = new();
        public PosterSettings PosterSettings { get; protected set; } = new();

    }
    
}