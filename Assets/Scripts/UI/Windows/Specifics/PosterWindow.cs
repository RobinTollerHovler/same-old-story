using Core.Movies;
using SameOldStory.Core.Movies;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class PosterWindow : Window {

        private Script script;
        
        public override void Submit() {
            Movie.StartProduction(script);
            Close();
        }

        private void OpenWindowForScript(Script script) {
            this.script = script;
            Open();
        }
        
        private void OnEnable() => Script.onRequestCreateMoviePoster += OpenWindowForScript;
        private void OnDisable() => Script.onRequestCreateMoviePoster -= OpenWindowForScript;
        
    }
    
}