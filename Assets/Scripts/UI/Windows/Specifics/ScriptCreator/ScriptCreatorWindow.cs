using System.Collections.Generic;
using System.Linq;
using Core.Movies;
using Core.People;
using Core.Roles;
using SameOldStory.Core.Studios;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ScriptCreatorWindow : Window {
        
        private RoleThumbnail[] roleThumbnails;
        private ProductTitleInputField productTitleInputField;
        private ProductGenreDropdown productGenreDropdown;

        public override void Submit() {
            Script.CurrentlyCreating.Title = productTitleInputField?.Text;
            Script.CurrentlyCreating.Genre = Studio.Current.GetGenreWithName(productGenreDropdown.Selected());
            Script.CurrentlyCreating.Create();
            Close();
        }
        
        protected override void SetUp() {
            productTitleInputField = GetComponentsInChildren<ProductTitleInputField>(true).FirstOrDefault();
            productGenreDropdown = GetComponentsInChildren<ProductGenreDropdown>(true).FirstOrDefault();
        }

        protected override void OnOpen() {
            Script.CurrentlyCreating.onRolesUpdated += UpdateRoles;
            Studio.Current.Roster.onRosterUpdated += UpdateRoles;
            productTitleInputField?.Clear();
            UpdateRoles();
        }

        protected override void OnClose() {
            Script.CurrentlyCreating.onRolesUpdated -= UpdateRoles;
            Studio.Current.Roster.onRosterUpdated -= UpdateRoles;
        }

        private void OnEnable() => Script.onRequestInitializeNewScript += Open;
        private void OnDisable() => Script.onRequestInitializeNewScript -= Open;

        private void UpdateRoles() {
            roleThumbnails = GetComponentsInChildren<RoleThumbnail>();
            foreach(RoleThumbnail roleThumbnail in roleThumbnails) roleThumbnail.Hide();
            Dictionary<Actor, Role> roles = Script.CurrentlyCreating.Roles;
            int i = 0;
            foreach (var set in roles) {
                if(roleThumbnails.Length > i) roleThumbnails[i].Show(set.Key, set.Value);
                i++;
            }
            if (roleThumbnails.Length > roles.Count && Studio.Current.Roster.Actors.Count(actor => !actor.IsWorking) > 0) {
                roleThumbnails[roles.Count].Show();
            } else if (roleThumbnails.Length > roles.Count) {
                roleThumbnails[roles.Count].ShowUnavailable();
            }
        }
        
    }
    
}