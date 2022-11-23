using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SameOldStory.UI.Transforms {
    
    [RequireComponent(typeof(RectTransform))]
    public class RectTransformShifter : MonoBehaviour {

        private RectTransform rectTransform;

        private void Awake() => rectTransform = GetComponent<RectTransform>();

        public void SetAt(float x, float y) {
            Debug.Log(rectTransform);
            if (rectTransform == null) return;
            StopAllCoroutines();
            StartCoroutine(Shift(x,y));
        }

        private IEnumerator Shift(float x, float y) {
            Debug.Log("Before");
            Debug.Log(Vector2.Distance(rectTransform.anchoredPosition, new Vector2(x, y)));
            while (Vector2.Distance(rectTransform.anchoredPosition, new Vector2(x, y)) > 0.1f) {
                Debug.Log("Enter");
                Vector2.Lerp(rectTransform.anchoredPosition, new Vector2(x, y), Time.deltaTime);
                Debug.Log("Ledt");
                yield return null;
            }
        }

    }
    
}