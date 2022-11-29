using System;
using SameOldStory.Core.Data;
using SameOldStory.Core.Movies;
using TMPro;
using UnityEngine;

namespace Core.Movies {
    
    public class PosterSettings {
        
        private Color posterBackgroundColor;
        private Color posterTextColor;
        private TMP_FontAsset tmpFontAsset;
        
        public event Action onPosterInformationChanged;

        public PosterSettings() {
            PosterBackgroundColor = Color.white;
            PosterTextColor = Color.black;
        }
        
        public Color PosterBackgroundColor {
            get => posterBackgroundColor;
            set {
                posterBackgroundColor = value;
                onPosterInformationChanged?.Invoke();
            }
        }

        public Color PosterTextColor {
            get => posterTextColor;
            set {
                posterTextColor = value;
                onPosterInformationChanged?.Invoke();
            }
        }

        public TMP_FontAsset PosterFont {
            get => tmpFontAsset;
            set {
                tmpFontAsset = value;
                onPosterInformationChanged?.Invoke();
            }
        }  
        
    }
    
}