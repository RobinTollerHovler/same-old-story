using Core.Movies;
using SameOldStory.Objects.Interactables.Posters.Components;
using TMPro;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters {
    
    public abstract class Poster : InteractableObject {

        [SerializeField] private TMP_FontAsset defaultFont;
        
        private Product product;
        private PosterMovieTitleText posterMovieTitleText;
        private PosterBackground posterBackground;

        protected PosterNode PosterNode { get; private set; }
        
        public void AssignProduct(Product assignProduct) {
            if (assignProduct == null) {
                if (product != null) product.PosterSettings.onPosterInformationChanged -= UpdatePosterLook;
            } else {
                assignProduct.PosterSettings.onPosterInformationChanged += UpdatePosterLook;
                product = assignProduct;
            }
            UpdatePosterLook();
        }

        private void UpdatePosterLook() {
            posterMovieTitleText?.Set(product?.Title ?? "Untitled");
            posterMovieTitleText?.SetColor(product == null ? Color.black : product.PosterSettings.PosterTextColor);
            posterMovieTitleText?.SetFont(product == null ? defaultFont : product.PosterSettings.PosterFont);
            posterBackground?.SetColor(product == null ? Color.white : product.PosterSettings.PosterBackgroundColor);
        }

        protected virtual void Awake() {
            posterMovieTitleText = GetComponentInChildren<PosterMovieTitleText>();
            PosterNode = GetComponentInChildren<PosterNode>();
            posterBackground = GetComponentInChildren<PosterBackground>();
        }
        
    }
    
}