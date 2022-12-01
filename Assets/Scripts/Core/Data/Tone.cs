using UnityEngine;

namespace SameOldStory.Core.Data {
    
    [CreateAssetMenu(fileName = "New Tone", menuName = "Data/Tone")]
    public class Tone : UnlockableStudioData {

        [Header("Tone options")]
        [SerializeField] private string label;
        [SerializeField] private Color color;

        public Color Value => color;
        public string Label => label;

        public float Hue {
            get {
                Color.RGBToHSV(Value, out float h, out float s, out float v);
                return h;
            }
        }

    }
    
}