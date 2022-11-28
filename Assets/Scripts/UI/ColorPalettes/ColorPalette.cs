using System.Collections.Generic;
using SameOldStory.Core.Data;
using SameOldStory.Core.Studios;
using UnityEngine;

namespace UI.ColorPalettes {
    
    public class ColorPalette : MonoBehaviour {

        [SerializeField] private int columns;
        [SerializeField] private float margin;
        [SerializeField] private GameObject swatchTemplate;

        private ColorPaletteNode colorPaletteNode;

        private void Awake() => colorPaletteNode = GetComponentInChildren<ColorPaletteNode>();
        
        private void Start() {
            
            IEnumerable<Tone> tones = Studio.Current.AvailableColors;
            int currentColumn = 0;
            int currentRow = 0;
            foreach (Tone tone in tones) {
                if (currentColumn < columns) {
                    currentColumn = 0;
                    currentRow++;
                }
                GameObject newSwatch = Instantiate(swatchTemplate, colorPaletteNode.transform);
                newSwatch.name = tone.Label;
                Swatch swatch = newSwatch.GetComponent<Swatch>();
                if (swatch != null) swatch.Tone = tone;
                RectTransform rectTransform = newSwatch.GetComponent<RectTransform>();
                if (rectTransform != null) {
                    rectTransform.anchoredPosition = new Vector2(currentColumn * margin, currentRow * margin);
                }
                currentColumn++;
            }
            
        }
        
    }
    
}