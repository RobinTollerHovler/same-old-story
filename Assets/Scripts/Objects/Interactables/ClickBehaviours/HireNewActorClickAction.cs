using SameOldStory.Core.Studios;

namespace SameOldStory.Objects.Interactables.ClickBehaviours {
    
    public class HireNewActorClickAction : ClickAction {
        
        public override void Click() {
            if (Studio.Current.Wallet.CanAfford(Studio.Current.Roster.NextActorHiringCost)) {
                Studio.Current.Wallet.Buy(Studio.Current.Roster.NextActorHiringCost);
                Studio.Current.Roster.HireActor();
            }    
        }
        
    }
    
}