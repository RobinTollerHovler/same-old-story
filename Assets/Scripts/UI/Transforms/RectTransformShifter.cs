using System.Collections;
using UnityEngine;

namespace SameOldStory.UI.Transforms {
    
    [RequireComponent(typeof(RectTransform))]
    public class RectTransformShifter : MonoBehaviour {

        private RectTransform rectTransform;
        private float shiftSpeed = 4;

        private void Awake() => rectTransform = GetComponent<RectTransform>();

        public void SetAt(float x, float y) {
            Debug.Log(rectTransform);
            if (rectTransform == null) return;
            StopAllCoroutines();
            StartCoroutine(Shift(x,y));
        }

        private IEnumerator Shift(float x, float y) {
            while (Vector2.Distance(rectTransform.anchoredPosition, new Vector2(x, y)) > 0.1f) {
                rectTransform.anchoredPosition = Vector2.Lerp(
                    rectTransform.anchoredPosition, new Vector2(x, y), 
                    shiftSpeed * Time.deltaTime
                );
                yield return null;
            }
            rectTransform.anchoredPosition = new Vector2(x, y);
        }

    }
    
}