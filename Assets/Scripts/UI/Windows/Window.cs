using System;
using UnityEngine;

namespace SameOldStory.UI.Windows {
    
    public abstract class Window : MonoBehaviour {

        [SerializeField] private ContentSet initialContentSet;
        private ContentSet activeContentSet;
        
        public event Action onActiveContentSetChanged;

        public ContentSet ActiveContentSet {
            get => activeContentSet;
            set {
                activeContentSet = value;
                onActiveContentSetChanged?.Invoke();
            }
        }

        public abstract void Submit();
        
        public void Close() => gameObject.SetActive(false);
        
        private void OnEnable() {
            ActiveContentSet = initialContentSet;
        }

        private void Start() => ActiveContentSet = initialContentSet;

    }
    
}