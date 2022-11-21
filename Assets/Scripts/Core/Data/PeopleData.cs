using UnityEngine;

namespace SameOldStory.Core.Data.People {
    
    [CreateAssetMenu(fileName = "New People Template", menuName = "Data/PeopleTemplate")]
    public class PeopleTemplate : ScriptableObject {

        [Header("Sprites")]
        [SerializeField] private Sprite[] hairStyles;
        [SerializeField] private Sprite[] faces;
        [SerializeField] private Sprite[] eyes;
        [SerializeField] private Sprite[] noses;
        [SerializeField] private Sprite[] mouths;

        [Header("Colors")]
        [SerializeField] private Color[] hairColors;
        [SerializeField] private Color[] skinTones;
        
        public Sprite[] HairStyles => hairStyles;
        public Sprite[] Faces => faces;
        public Sprite[] Eyes => eyes;
        public Sprite[] Noses => noses;
        public Sprite[] Mouths => mouths;
        public Color[] HairColors => hairColors;
        public Color[] SkinTones => skinTones;

        public Sprite RandomHairStyle => hairStyles[Random.Range(0, hairStyles.Length)];
        public Sprite RandomFace => faces[Random.Range(0, faces.Length)];
        public Sprite RandomEyes => eyes[Random.Range(0, eyes.Length)];
        public Sprite RandomNose => noses[Random.Range(0, noses.Length)];
        public Sprite RandomMouth => mouths[Random.Range(0, mouths.Length)];
        public Color RandomHairColor => hairColors[Random.Range(0, hairColors.Length)];
        public Color RandomSkinTone => skinTones[Random.Range(0, skinTones.Length)];
        

    }
    
}