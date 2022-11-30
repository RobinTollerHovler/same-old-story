using SameOldStory.Input.Mouse;
using TMPro;
using UnityEngine;

namespace SameOldStory.UI.Tooltips {
    
    public class Tooltip : MonoBehaviour {

        private TextMeshProUGUI textMeshProUGUI;
        private Animator animator;
        private Canvas canvas;
        
        private void Awake() {
            textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
            animator = GetComponent<Animator>();
            canvas = GetComponentInParent<Canvas>();
        }

        private void Update() {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(Mouse.Position.x, Mouse.Position.y) / canvas.transform.localScale.x;
        }

        private void OnEnable() => Mouse.objectUnderCursorChanged += UpdateTooltip;
        private void OnDisable() => Mouse.objectUnderCursorChanged -= UpdateTooltip;

        private void UpdateTooltip() {
            GameObject objectUnderCursor = Mouse.ObjectUnderCursor;
            IHaveTooltip tooltip = objectUnderCursor.GetComponentInParent<IHaveTooltip>();
            if (tooltip != null && textMeshProUGUI != null) {
                textMeshProUGUI.text = tooltip.Tooltip;
                RectTransform rectTransform = GetComponent<RectTransform>();
                Vector3 screenPosition = Camera.main.ScreenToViewportPoint(objectUnderCursor.transform.position);
                rectTransform.anchoredPosition = new Vector2(
                    screenPosition.x,
                    screenPosition.y
                );
                animator?.SetBool("Display", true);
            } else {
                animator?.SetBool("Display", false);
            }
        }
        
    }
    
}