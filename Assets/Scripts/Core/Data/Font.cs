using TMPro;
using UnityEngine;

namespace SameOldStory.Core.Data {
    
    [CreateAssetMenu(fileName = "New Font", menuName = "Data/Font")]
    public class Font : UnlockableStudioData {

        [Header("Font options")]
        [SerializeField] private string fontName;
        [SerializeField] private TMP_FontAsset tmpFontAsset;

        public string Name => fontName;
        public TMP_FontAsset FontAsset => tmpFontAsset;

    }
    
}