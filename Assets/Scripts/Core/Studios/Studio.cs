using System.Linq;
using SameOldStory.Core.Data;
using UnityEngine;

namespace SameOldStory.Core.Studios {
    
    public class Studio {
    
        public static Studio Current { get; private set; }

        private Genre[] genres;
        private Tone[] colors;
        
        public Genre[] AvailableGenres => genres.Where(g => g.StartAvailable).ToArray();
        public Tone[] AvailableColors => colors; 

        public static void InitializeNewStudio() {
            Current = new Studio {
                genres = Resources.LoadAll("Genres", typeof(Genre)).Cast<Genre>().ToArray(),
                colors = Resources.LoadAll("Colors", typeof(Tone)).Cast<Tone>().ToArray()
            };
        }

        public Genre GetGenreWithName(string genreName) {
            return genres.FirstOrDefault(g => g.name == genreName);
        }

    }
    
}