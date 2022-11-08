using System;
using UnityEngine;

namespace SameOldStory.Input {

    public interface IStudioInput {
        public Vector2 MousePosition { get; }
        public event Action onMouseClick;
    }
    
}
    
