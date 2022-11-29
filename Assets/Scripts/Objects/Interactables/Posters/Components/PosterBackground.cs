using SameOldStory.Core.Data;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Posters.Components {
    
    public class PosterBackground : MonoBehaviour {

        private SpriteRenderer spriteRenderer;

        private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

        public void SetColor(Color color) {
            if(spriteRenderer != null) spriteRenderer.color = color;
        }

    }
    
}