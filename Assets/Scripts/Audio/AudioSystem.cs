using System;

namespace SameOldStory.Audio {
    
    public static class AudioSystem {

        public static event Action<AudioPlayRequest> onAudioPlayRequest;

        public static void Play(AudioPlayRequest request) => onAudioPlayRequest?.Invoke(request);

    }
    
}