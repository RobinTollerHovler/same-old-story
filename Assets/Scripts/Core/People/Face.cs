using System.Linq;
using SameOldStory.Core.Data.People;
using UnityEngine;

namespace Core.People {
    
    public class Face {

        private static PeopleTemplate[] cachedMaleFaceTemplates;
        private static PeopleTemplate[] cachedFemaleFaceTemplates;

        private Sprite HairStyle { get; }
        private Sprite FaceType { get; }
        private Sprite Eyes { get; }
        private Sprite Nose { get; }
        private Sprite Mouth { get; }
        private Color HairColor { get; }
        private Color SkinTone { get; }

        public Face(Gender gender) {
            if (!FaceTemplatesLoaded) LoadFaceTemplates();
            switch (gender) {
                case Gender.Male:
                    PeopleTemplate maleTemplate = cachedMaleFaceTemplates[Random.Range(0, cachedMaleFaceTemplates.Length)];
                    HairStyle = maleTemplate.RandomHairStyle;
                    FaceType = maleTemplate.RandomFace;
                    Eyes = maleTemplate.RandomEyes;
                    Nose = maleTemplate.RandomNose;
                    Mouth = maleTemplate.RandomMouth;
                    HairColor = maleTemplate.RandomHairColor;
                    SkinTone = maleTemplate.RandomSkinTone;
                    break;
                case Gender.Female:
                    PeopleTemplate femaleTemplate = cachedFemaleFaceTemplates[Random.Range(0, cachedFemaleFaceTemplates.Length)];
                    HairStyle = femaleTemplate.RandomHairStyle;
                    FaceType = femaleTemplate.RandomFace;
                    Eyes = femaleTemplate.RandomEyes;
                    Nose = femaleTemplate.RandomNose;
                    Mouth = femaleTemplate.RandomMouth;
                    HairColor = femaleTemplate.RandomHairColor;
                    SkinTone = femaleTemplate.RandomSkinTone;
                    break;
            }
        }
        
        private static void LoadFaceTemplates() {
            cachedMaleFaceTemplates ??= Resources.LoadAll("PeopleTemplates", typeof(PeopleTemplate)).Cast<PeopleTemplate>().Where(p => p.Gender == Gender.Male).ToArray();
            cachedFemaleFaceTemplates ??= Resources.LoadAll("PeopleTemplates", typeof(PeopleTemplate)).Cast<PeopleTemplate>().Where(p => p.Gender == Gender.Female).ToArray();
        }
        
        private static bool FaceTemplatesLoaded => cachedMaleFaceTemplates != null || cachedFemaleFaceTemplates != null;

        
    }
    
}

