using Core.Movies;
using SameOldStory.UI.Components;
using UnityEngine;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ProductTitleInputField : InputFieldComponent {
        
        protected override void OnValueChanged(string value) {
            base.OnValueChanged(value);
            if(Script.CurrentlyCreating != null) Script.CurrentlyCreating.Title = value;
        }
        
    }
    
}