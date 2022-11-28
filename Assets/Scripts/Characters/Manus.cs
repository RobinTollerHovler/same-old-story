using Core.Movies;
using SameOldStory.Core.Movies;
using UnityEngine;

namespace Characters {

    public class Manus : MonoBehaviour {

        private ManusArm[] arms;

        private void Awake() {
            arms = GetComponentsInChildren<ManusArm>();
        }

        private void OnEnable() => Script.onCurrentlyWritingScriptChanged += CurrentlyWritingScriptChanged;
        private void OnDisable() => Script.onCurrentlyWritingScriptChanged -= CurrentlyWritingScriptChanged;

        private void CurrentlyWritingScriptChanged(Script script) {
            if (script == null || script.WriteProgress >= 1) {
                foreach(ManusArm arm in arms) arm.EndTyping();
            } else {
                foreach(ManusArm arm in arms) arm.BeginTyping();
            }
        }

    }
    
}