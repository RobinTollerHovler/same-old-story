using Core.Movies;
using SameOldStory.Core.Movies;
using SameOldStory.Objects.Interactables.Posters.Components;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public abstract class Poster : InteractableObject {

        protected Product product;
        private PosterMovieTitleText posterMovieTitleText;

        protected PosterNode PosterNode { get; private set; }
        
        public void AssignProduct(Product product) {
            if (product == null) return;
            this.product = product;
            posterMovieTitleText?.Set(product.Title);
        }

        protected virtual void Awake() {
            posterMovieTitleText = GetComponentInChildren<PosterMovieTitleText>();
            PosterNode = GetComponentInChildren<PosterNode>();
        }
        
    }
    
}