using System.Collections.Generic;
using Core.Roles;
using SameOldStory.Core.Data;

namespace Core.Movies {
    
    public abstract class Product {

        public string Title { get; protected set; }
        public Genre Genre { get; protected set; }
        public List<Role> Roles { get; protected set; } = new();

    }
    
}