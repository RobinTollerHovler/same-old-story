using Core.People;
using TMPro;
using UnityEngine;
using Button = SameOldStory.UI.Buttons.Button;

namespace UI.Windows.Specifics.ScriptCreator.Roles {
    
    public class ActorForRoleButton : Button {

        [SerializeField] private TextMeshProUGUI actorNameText;
        [SerializeField] private TextMeshProUGUI actorWageText;

        public void AssignActor(Actor actor) {
            actorNameText.text = actor.Name;
            actorWageText.text = $"$0 /m";
        }

    }
    
}