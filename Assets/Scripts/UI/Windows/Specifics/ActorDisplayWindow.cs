using System;
using Core.People;
using SameOldStory.Input.Mouse;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ActorDisplayWindow : MonoBehaviour {

        private WindowActivationNode windowActivationNode;
        
        [SerializeField] private Image face;
        [SerializeField] private Image eyes;
        [SerializeField] private Image nose;
        [SerializeField] private Image mouth;
        [SerializeField] private Image hair;
        [SerializeField] private TextMeshProUGUI actorName;
        [SerializeField] private TextMeshProUGUI actorWage;
        [SerializeField] private TextMeshProUGUI actorGoodGenres;
        [SerializeField] private TextMeshProUGUI actorBadGenres;

        private void Awake() => windowActivationNode = GetComponentsInChildren<WindowActivationNode>(true)[0];
        
        private void OnEnable() {
            windowActivationNode?.Deactivate();
            Mouse.objectUnderCursorChanged += DisplayActorInfo;
        }

        private void OnDisable() {
            Mouse.objectUnderCursorChanged -= DisplayActorInfo;
        }

        private void DisplayActorInfo() {
            GameObject obj = Mouse.ObjectUnderCursor;
            IRepresentActor actor = obj.GetComponentInParent<IRepresentActor>();
            if (actor == null) {
                windowActivationNode.Deactivate();
                return;
            }
            if (actor.Actor == null) return;
            windowActivationNode.Activate();
            actorName.text = actor.Actor.Name;
            face.sprite = actor.Actor.Face.FaceType;
            eyes.sprite = actor.Actor.Face.Eyes;
            nose.sprite = actor.Actor.Face.Nose;
            mouth.sprite = actor.Actor.Face.Mouth;
            hair.sprite = actor.Actor.Face.HairStyle;
            hair.color = actor.Actor?.Face.HairColor ?? Color.white;
            nose.color = actor.Actor?.Face.HairColor ?? Color.white;
            face.color = actor.Actor?.Face.SkinTone ?? Color.white;
        }
        
    }
    
}