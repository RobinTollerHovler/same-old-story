using SameOldStory.Core.Data;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace UI.ColorPalettes {
    
    public class ColorPalette : MonoBehaviour {

        [SerializeField] private GameObject swatchTemplate;
        
        private float margin = 30;

        private ColorPaletteNode colorPaletteNode;

        private void Awake() => colorPaletteNode = GetComponentInChildren<ColorPaletteNode>();
        
        private void Start() {
            
            Tone[] tones = Studio.Current.AvailableColors;
            int column = 0;
            int row = 0;
            foreach (var t in tones) {
                GameObject newSwatch = Instantiate(swatchTemplate, colorPaletteNode.transform);
                newSwatch.name = t.Label;
                Swatch swatch = newSwatch.GetComponent<Swatch>();
                if (swatch != null) swatch.Tone = t;
                RectTransform rectTransform = newSwatch.GetComponent<RectTransform>();
                if (rectTransform != null) rectTransform.anchoredPosition = new Vector2(column * margin, -(row * margin));
                column++;
                if (column <= 3) continue;
                column = 0;
                row++;
            }

        }
        
    }
    
}