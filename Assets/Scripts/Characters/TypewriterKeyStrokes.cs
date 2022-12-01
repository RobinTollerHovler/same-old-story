using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters {
    
    public class TypewriterKeyStrokes : MonoBehaviour {

        [SerializeField] private AudioClip audioClip;
        private AudioSource audioSource;

        private void Awake() => audioSource = GetComponent<AudioSource>();

        public void PlayStroke() {
            audioSource.clip = audioClip;
            audioSource.pitch = 1 + Random.Range(-.07f, .07f);
            audioSource.Play();
        }

    }
    
}