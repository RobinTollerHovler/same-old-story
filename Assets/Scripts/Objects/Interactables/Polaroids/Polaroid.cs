using Core.People;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.PeopleFrames {

    public class Polaroid : InteractableObject {

        [SerializeField] private SpriteRenderer face;
        [SerializeField] private SpriteRenderer eyes;
        [SerializeField] private SpriteRenderer nose;
        [SerializeField] private SpriteRenderer mouth;
        [SerializeField] private SpriteRenderer hair;

        private void Start() => DisplayPerson();
        
        private void DisplayPerson() {
            Actor p = new Actor();
            Tooltip = p.Name;
            face.sprite = p.Face.FaceType;
            eyes.sprite = p.Face.Eyes;
            nose.sprite = p.Face.Nose;
            mouth.sprite = p.Face.Mouth;
            hair.sprite = p.Face.HairStyle;
            hair.color = p.Face.HairColor;
            nose.color = p.Face.HairColor;
            face.color = p.Face.SkinTone;
        }

    }
    
}