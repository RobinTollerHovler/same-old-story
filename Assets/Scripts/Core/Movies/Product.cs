using System.Collections.Generic;
using Core.Roles;

namespace Core.Movies {
    
    public abstract class Product {

        public string Title { get; set; }
        public List<Role> Roles { get; private set; }

    }
    
}