using System;
using Core.People;
using SameOldStory.Core.Studios;

namespace SameOldStory.Objects.Interactables.PeopleFrames {
    
    public class SackActorButton : InteractableObject {
        
        private void OnEnable() {
            IRepresentActor actor = GetComponentInParent<IRepresentActor>();
            if (actor != null) Tooltip = $"Sack {actor.Actor?.Name}";
        }

        public override void MouseClick() {
            base.MouseClick();
            IRepresentActor actor = GetComponentInParent<IRepresentActor>();
            if (actor != null) Studio.Current.Roster.SackActor(actor.Actor);
        }
        
    }
    
}