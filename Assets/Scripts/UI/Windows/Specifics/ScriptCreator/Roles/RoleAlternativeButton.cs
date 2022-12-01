using System.Linq;
using Core.Movies;
using Core.Roles;
using SameOldStory.Core.Studios;
using SameOldStory.UI.Buttons;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI.Windows.Specifics.MovieMaker.Roles {
    
    public class RoleAlternativeButton : Button {
        
        private Role role;
        [SerializeField] private Color positiveColor;
        [SerializeField] private Color negativeColor;
        
        protected override void Click() {
            base.Click();
            Script.CurrentlyCreating.AddRole(role);
        }
        
        private void OnEnable() {
            role = Studio.Current.AvailableRoles[
                Random.Range(0, Studio.Current.AvailableRoles.Length)
            ];
            SetText(role.RoleTitle);
            if (!role.TestedGenres.Contains(Script.CurrentlyCreating.Genre)) return;
            if (role.FittingGenres.Contains(Script.CurrentlyCreating.Genre)) SetColor(positiveColor);
            else if (role.UnfittingGenres.Contains(Script.CurrentlyCreating.Genre)) SetColor(negativeColor);
        }
        
    }
    
}