using System.Collections;
using UnityEngine;

namespace Characters {
    
    public class ManusArm : MonoBehaviour {

        private Animator animator;

        public void BeginTyping() {
            StopAllCoroutines();
            StartCoroutine(nameof(Type));
        }

        public void EndTyping() {
            StopAllCoroutines();
        }
        
        private void Awake() => animator = GetComponent<Animator>();

        private IEnumerator Type() {
            while (true) {
                while (animator == null) yield return null;
                string trigger = Random.Range(0, 5) switch {
                    0 => "Low",
                    1 => "MediumLow",
                    2 => "Medium",
                    3 => "MediumHigh",
                    4 => "High",
                    _ => "Low"
                };
                animator.SetTrigger(trigger);
                yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
            }
        }

    }
    
}