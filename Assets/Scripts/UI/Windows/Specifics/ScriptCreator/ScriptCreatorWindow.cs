using System;
using System.Linq;
using Core.Movies;
using Core.Roles;
using SameOldStory.Core.Movies;
using SameOldStory.Core.Studios;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ScriptCreatorWindow : Window {
        
        private RoleThumbnail[] roleThumbnails;
        private ProductTitleInputField productTitleInputField;
        private ProductGenreDropdown productGenreDropdown;


        public override void Submit() {
            Movie newMovie = new Movie(
                productTitleInputField?.Text,
                Studio.Current.GetGenreWithName(productGenreDropdown.Selected())
            );
            newMovie.Activate();
            productTitleInputField?.Clear();
            Close();
        }
        
        protected override void SetUp() {
            productTitleInputField = GetComponentsInChildren<ProductTitleInputField>(true).FirstOrDefault();
            productGenreDropdown = GetComponentsInChildren<ProductGenreDropdown>(true).FirstOrDefault();
        }

        protected override void OnOpen() {
            Script.CurrentlyCreating.onRolesUpdated += UpdateRoles;
            UpdateRoles();
        }

        protected override void OnClose() {
            Script.CurrentlyCreating.onRolesUpdated -= UpdateRoles;
        }

        private void OnEnable() => Script.onRequestCreateNewScript += Open;
        private void OnDisable() => Script.onRequestCreateNewScript -= Open;

        private void UpdateRoles() {
            roleThumbnails = GetComponentsInChildren<RoleThumbnail>();
            foreach(RoleThumbnail roleThumbnail in roleThumbnails) roleThumbnail.Hide();
            Role[] roles = Script.CurrentlyCreating.Roles.ToArray();
            for (int i = 0; i < roles.Length; i++) {
                if(roleThumbnails.Length > i) roleThumbnails[i].Show(roles[i]);
            }
            if(roleThumbnails.Length > roles.Length) roleThumbnails[roles.Length].Show();
        }
        
    }
    
}