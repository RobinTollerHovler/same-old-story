using System.Collections.Generic;
using System.Linq;
using SameOldStory.Core.Data;
using UnityEngine;
using Font = SameOldStory.Core.Data.Font;

namespace SameOldStory.Core.Studios {
    
    public class Studio {
    
        public static Studio Current { get; private set; }

        private Genre[] genres;
        private Tone[] colors;
        private Font[] fonts;
        
        public IEnumerable<Genre> AvailableGenres => genres.Where(g => g.StartAvailable).ToArray();
        public IEnumerable<Tone> AvailableColors => colors;
        public IEnumerable<Font> AvailableFonts => fonts;

        public static void InitializeNewStudio() {
            Current = new Studio {
                genres = Resources.LoadAll("Genres", typeof(Genre)).Cast<Genre>().ToArray(),
                colors = Resources.LoadAll("Colors", typeof(Tone)).Cast<Tone>().ToArray(),
                fonts = Resources.LoadAll("Fonts", typeof(Font)).Cast<Font>().ToArray()
            };
        }

        public Genre GetGenreWithName(string genreName) {
            return genres.FirstOrDefault(g => g.name == genreName);
        }

    }
    
}