using UnityEngine;

namespace SameOldStory.UI.Windows {
    
    public class ContentSet : MonoBehaviour {

        [SerializeField] private string title;
        [SerializeField] private ContentSet nextContentSet;
        [SerializeField] private ContentSet previousContentSet;

        private Window window;
        
        public string Title => title;
        public ContentSet Next => nextContentSet;
        public ContentSet Previous => previousContentSet;

        private void Awake() => window = GetComponentInParent<Window>();
        
        private void Start() {
            if (window != null) window.onActiveContentSetChanged += CheckActivation;
            CheckActivation();
        }

        private void OnDestroy() {
            if (window != null) window.onActiveContentSetChanged -= CheckActivation;
        }

        private void CheckActivation() => gameObject.SetActive(window.ActiveContentSet == this);
        
    }
    
}