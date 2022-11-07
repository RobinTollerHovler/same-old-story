using SameOldStory.Input.Mouse;
using TMPro;
using UnityEngine;

namespace UI.Tooltips {
    
    public class Tooltip : MonoBehaviour {

        private TextMeshProUGUI textMeshProUGUI;
        private Animator animator;
        
        private void Awake() {
            textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
            animator = GetComponent<Animator>();
        }

        private void Update() {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(
                Mouse.Position.x - (float)Screen.width / 2,
                Mouse.Position.y - (float)Screen.height / 2
            );
        }

        private void OnEnable() => Mouse.objectUnderCursorChanged += UpdateTooltip;
        private void OnDisable() => Mouse.objectUnderCursorChanged -= UpdateTooltip;

        private void UpdateTooltip() {
            GameObject objectUnderCursor = Mouse.ObjectUnderCursor;
            IHaveTooltip tooltip = objectUnderCursor.GetComponentInParent<IHaveTooltip>();
            if (tooltip != null && textMeshProUGUI != null) {
                textMeshProUGUI.text = tooltip.Tooltip;
                animator?.SetBool("Display", true);
            } else {
                animator?.SetBool("Display", false);
            }
        }
        
    }
    
}