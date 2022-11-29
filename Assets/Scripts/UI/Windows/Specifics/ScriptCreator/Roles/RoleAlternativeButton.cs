using Core.Movies;
using Core.Roles;
using SameOldStory.Core.Studios;
using SameOldStory.UI.Buttons;
using Random = UnityEngine.Random;

namespace UI.Windows.Specifics.MovieMaker.Roles {
    
    public class RoleAlternativeButton : Button {
        
        private Role role;

        protected override void Click() {
            base.Click();
            Script.CurrentlyCreating.AddRole(role);
            
        }
        
        private void OnEnable() {
            role = Studio.Current.AvailableRoles[
                Random.Range(0, Studio.Current.AvailableRoles.Length)
            ];
            SetText(role.RoleTitle);
        }
        
    }
    
}