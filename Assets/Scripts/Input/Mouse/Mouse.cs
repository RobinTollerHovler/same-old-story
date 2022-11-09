using System;
using UnityEngine;

namespace SameOldStory.Input.Mouse {
    
    public static class Mouse {
        private static GameObject objectUnderCursor;

        public static GameObject ObjectUnderCursor {
            get => objectUnderCursor;
            set {
                if (objectUnderCursor == value) return;
                objectUnderCursor = value;
                objectUnderCursorChanged?.Invoke();
            }
        }

        public static Vector3 ObjectUnderCursorHitPoint { get; set; }

        public static Vector2 Position { get; set; }

        public static event Action objectUnderCursorChanged;

    }
    
    
}