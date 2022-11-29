using System;
using SameOldStory.Core.Data;
using TMPro;

namespace Core.Movies {
    
    public class PosterSettings {
        
        private Tone posterBackgroundColor;
        private Tone posterTextColor;
        private TMP_FontAsset tmpFontAsset;
        
        public event Action onPosterInformationChanged;
        
        public Tone PosterBackgroundColor {
            get => posterBackgroundColor;
            set {
                posterBackgroundColor = value;
                onPosterInformationChanged?.Invoke();
            }
        }

        public Tone PosterTextColor {
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