using UnityEngine;

namespace SameOldStory.Audio {
    
    public struct AudioPlayRequest {
        
        public AudioClip Clip { get; set; } 
        public string Channel { get; set; }

        public AudioPlayRequest(AudioClip clip, string channel = "default") {
            Clip = clip;
            Channel = channel;
        }
        
    }
    
}