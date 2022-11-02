using UnityEngine;

namespace SameOldStory.Audio {
    
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayerChannel : MonoBehaviour {

        [SerializeField] private string channelName;
        private AudioSource audioSource;

        public string ChannelName {
            get => channelName;
            private set => channelName = value;
        }

        public void PlayAudioOnChannel(AudioClip clip) {
            if (audioSource == null) return;
            audioSource.clip = clip;
            audioSource.Play();
        }
        
        private void Awake() => audioSource = GetComponent<AudioSource>();
        
    }
    
}