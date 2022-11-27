using System.Linq;
using SameOldStory.Core.Data.People;
using UnityEngine;

namespace Core.People {
    
    public class Face {

        private static MaleFaceTemplate[] cachedMaleFaceTemplates;
        private static FemaleFaceTemplate[] cachedFemaleFaceTemplates;

        public Sprite HairStyle { get; }
        public Sprite FaceType { get; }
        public Sprite Eyes { get; }
        public Sprite Nose { get; }
        public Sprite Mouth { get; }
        public Color HairColor { get; }
        public Color SkinTone { get; }

        public Face(Gender gender) {
            if (!FaceTemplatesLoaded) LoadFaceTemplates();
            FaceTemplate faceTemplate = gender switch {
                Gender.Male => cachedMaleFaceTemplates[Random.Range(0, cachedMaleFaceTemplates.Length)],
                Gender.Female => cachedFemaleFaceTemplates[Random.Range(0, cachedFemaleFaceTemplates.Length)]
            };
            HairStyle = faceTemplate.RandomHairStyle;
            FaceType = faceTemplate.RandomFace;
            Eyes = faceTemplate.RandomEyes;
            Nose = faceTemplate.RandomNose;
            Mouth = faceTemplate.RandomMouth;
            HairColor = faceTemplate.RandomHairColor;
            SkinTone = faceTemplate.RandomSkinTone;
        }
        
        private static void LoadFaceTemplates() {
            cachedMaleFaceTemplates ??= Resources.LoadAll("FaceTemplates", typeof(MaleFaceTemplate)).Cast<MaleFaceTemplate>().ToArray();
            cachedFemaleFaceTemplates ??= Resources.LoadAll("FaceTemplates", typeof(FemaleFaceTemplate)).Cast<FemaleFaceTemplate>().ToArray();
        }
        
        private static bool FaceTemplatesLoaded => cachedMaleFaceTemplates != null || cachedFemaleFaceTemplates != null;

        
    }
    
}

