using SameOldStory.Core;
using UnityEngine;

namespace SameOldStory.UI.TextDisplays {
    
    public class MovieEarningsTextDisplay : TextDisplay {
        
        private IRepresentMovie representMovie;
        [SerializeField] private Color negativeColor;
        [SerializeField] private Color positiveColor;

        private void Start() {
            representMovie = GetComponentInParent<IRepresentMovie>();
            representMovie.Movie.onEarningsChanged += UpdateEarnings;
            UpdateEarnings();
        }

        private void OnDisable() {
            representMovie.Movie.onEarningsChanged -= UpdateEarnings;
        }

        private void UpdateEarnings() {
            int currentEarnings = (int)representMovie.Movie.Earnings;
            SetColor(currentEarnings switch {
                < 0 => negativeColor,
                _ => positiveColor
            });
            SetText($"${currentEarnings}");
        }
        
    }
    
}