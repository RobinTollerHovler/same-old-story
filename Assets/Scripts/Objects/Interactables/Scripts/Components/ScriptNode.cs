using SameOldStory.Objects.Components;
using UnityEngine;

namespace SameOldStory.Objects.Interactables.Scripts.Components {
    
    public class ScriptNode : TransformComponent {

        private void Start() => SetLocalScale(new Vector3(1, 1 + Random.Range(-.2f, .09f), 1));

    }
    
}