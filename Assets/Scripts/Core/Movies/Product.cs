using System.Collections.Generic;
using Core.Roles;
using SameOldStory.Core.Data;

namespace Core.Movies {
    
    public abstract class Product {

        public string Title { get; set; }
        public Genre Genre { get; set; }
        public List<Role> Roles { get; protected set; } = new();

    }
    
}