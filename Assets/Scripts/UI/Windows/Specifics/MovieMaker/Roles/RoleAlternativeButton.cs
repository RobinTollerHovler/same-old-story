using Core.Roles;
using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;
using SameOldStory.UI.Buttons;
using SameOldStory.UI.Windows;
using UI.Menus;
using UnityEngine;

namespace UI.Windows.Specifics.MovieMaker.Roles {
    
    public class RoleAlternativeButton : Button {

        private Role role;

        protected override void Click() {
            base.Click();
            GetComponentInParent<RoleMenu>()?.Close();
            //GetComponentInChildren<ActorForRoleMenu>()?.Open();
        }
        
        private void OnEnable() {
            role = Studio.Current.AvailableRoles[
                Random.Range(0, Studio.Current.AvailableRoles.Length)
            ];
            SetText(role.RoleTitle);
        }
        
    }
    
}