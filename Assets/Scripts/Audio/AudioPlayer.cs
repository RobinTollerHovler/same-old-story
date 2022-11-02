using UnityEngine;

namespace SameOldStory.Audio {
    
    public class AudioPlayer : MonoBehaviour {

        private AudioPlayerChannel[] channels;
        
        private void OnEnable() => AudioSystem.onAudioPlayRequest += ProcessRequest;
        private void OnDisable() => AudioSystem.onAudioPlayRequest -= ProcessRequest;

        private void Start() {
            channels = GetComponentsInChildren<AudioPlayerChannel>();
        }
        
        private void ProcessRequest(AudioPlayRequest request) {
            if(channels.Length > 0) SendRequestToChannel(request);
        }

        private void SendRequestToChannel(AudioPlayRequest request) {
            foreach (AudioPlayerChannel channel in channels) {
                if (channel.ChannelName != request.Channel) continue;
                channel.PlayAudioOnChannel(request.Clip);
                return;
            }
        }
        
    }
    
}