using SameOldStory.Core.Movies;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class ProductionWindow : Window {
        
        public override void Submit() {
            Movie.Active.StartProduction();
            Close();
        }
        
    }
    
}