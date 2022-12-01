using System.Collections;
using UnityEngine;

namespace Characters {
    
    public class ManusArm : MonoBehaviour {

        private Animator animator;
        private bool isWriting = false;

        public void BeginTyping() {
            if(!isWriting) StartCoroutine(nameof(Type));
        }

        public void EndTyping() {
            StopAllCoroutines();
            isWriting = false;
        }
        
        private void Awake() => animator = GetComponent<Animator>();

        private IEnumerator Type() {
            isWriting = true;
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