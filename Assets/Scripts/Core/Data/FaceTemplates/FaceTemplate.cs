using Core.People;
using UnityEngine;

namespace SameOldStory.Core.Data.People {
    
    public abstract class FaceTemplate : ScriptableObject {

        [Header("Sprites")]
        [SerializeField] private Sprite[] hairStyles;
        [SerializeField] private Sprite[] faces;
        [SerializeField] private Sprite[] eyes;
        [SerializeField] private Sprite[] noses;
        [SerializeField] private Sprite[] mouths;

        [Header("Colors")]
        [SerializeField] private Color[] hairColors;
        [SerializeField] private Color[] skinTones;
        [SerializeField] private Color[] lipColors;

        public Sprite RandomHairStyle => hairStyles.Length == 0 ? null : hairStyles[Random.Range(0, hairStyles.Length)];
        public Sprite RandomFace => faces.Length == 0 ? null : faces[Random.Range(0, faces.Length)];
        public Sprite RandomEyes => eyes.Length == 0 ? null : eyes[Random.Range(0, eyes.Length)];
        public Sprite RandomNose => noses.Length == 0 ? null : noses[Random.Range(0, noses.Length)];
        public Sprite RandomMouth => mouths.Length == 0 ? null : mouths[Random.Range(0, mouths.Length)];
        public Color RandomHairColor => hairColors.Length == 0 ? Color.blue : hairColors[Random.Range(0, hairColors.Length)];
        public Color RandomSkinTone => skinTones.Length == 0 ? Color.blue : skinTones[Random.Range(0, skinTones.Length)];
        public Color RandomLipColor => lipColors.Length == 0 ? Color.blue : lipColors[Random.Range(0, lipColors.Length)];

    }
    
}