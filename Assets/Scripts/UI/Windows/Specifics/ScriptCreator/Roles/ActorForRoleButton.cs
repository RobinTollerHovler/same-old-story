using Core.People;
using Core.Roles;
using TMPro;
using UnityEngine;
using Button = SameOldStory.UI.Buttons.Button;

namespace UI.Windows.Specifics.ScriptCreator.Roles {
    
    public class ActorForRoleButton : Button {

        [SerializeField] private TextMeshProUGUI actorNameText;
        [SerializeField] private TextMeshProUGUI actorWageText;

        public void AssignActor(Actor actor, Role role) {
            actorNameText.text = actor.Name;
            actorWageText.text = $"$0 /m";
            
        }

        protected override void Click() {
            base.Click();
        }
        
    }
    
}