using Core.People;
using SameOldStory.Core.Studios;
using SameOldStory.Objects.Interactables.ClickBehaviours;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.PeopleFrames {

    public class Polaroid : InteractableObject, IRepresentActor {

        [SerializeField] private SpriteRenderer face;
        [SerializeField] private SpriteRenderer eyes;
        [SerializeField] private SpriteRenderer nose;
        [SerializeField] private SpriteRenderer mouth;
        [SerializeField] private SpriteRenderer hair;
        [SerializeField] private SpriteRenderer plusSprite;
        [SerializeField] private GameObject sackButton;
        [SerializeField] private GameObject actorOnSetIndicator;

        private PolaroidNode polaroidNode;

        private void Awake() => polaroidNode = GetComponentInChildren<PolaroidNode>();

        public Actor Actor { get; private set; }

        public void Show(Actor actor = null) {
            AssignActor(actor);
            polaroidNode?.Show();
        }

        public void Hide() {
            sackButton.SetActive(false);
            if (Actor != null) {
                Actor.onStartedWorking -= ActorStartedWorking;
                Actor.onFinishedWorking -= ActorFinishedWorking;
            }
            polaroidNode?.Hide();
        }

        private void AssignActor(Actor actor) {
            Actor = actor;
            if (Actor != null) {
                Actor.onStartedWorking += ActorStartedWorking;
                Actor.onFinishedWorking += ActorFinishedWorking;
            }
            UpdatePolaroid(actor);
        }

        private void ActorStartedWorking() {
            UpdatePolaroid(Actor);
        }

        private void ActorFinishedWorking() {
            UpdatePolaroid(Actor);
        }

        private void UpdatePolaroid(Actor actor) {
            sackButton.SetActive(actor is { IsWorking: false });
            actorOnSetIndicator.SetActive(actor is { IsWorking: true });
            Tooltip = actor != null ? actor.Name : $"Hire new actor ${Studio.Current.Roster.NextActorHiringCost}";
            ClickAction = actor != null ? new AddActorToRoleClickAction(actor) : new HireNewActorClickAction();
            plusSprite.enabled = actor == null;
            face.sprite = actor?.Face.FaceType;
            eyes.sprite = actor?.Face.Eyes;
            nose.sprite = actor?.Face.Nose;
            mouth.sprite = actor?.Face.Mouth;
            mouth.color = actor?.Face.LipColor ?? Color.white;
            hair.sprite = actor?.Face.HairStyle;
            hair.color = actor?.Face.HairColor ?? Color.white;
            nose.color = actor?.Face.HairColor ?? Color.white;
            face.color = actor?.Face.SkinTone ?? Color.white;
        }
        
    }
    
}