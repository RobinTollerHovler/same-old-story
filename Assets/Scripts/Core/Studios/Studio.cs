using System.Linq;
using SameOldStory.Core.Genres;
using UnityEngine;

namespace SameOldStory.Core.Studios {
    
    public class Studio {
    
        public static Studio Current { get; private set; }

        private Genre[] genres;
        
        public Genre[] AvailableGenres {
            get {
                return genres.Where(g => g.StartAvailable).ToArray();
            }
        }

        public static void InitializeNewStudio() {
            Current = new Studio {
                genres = Resources.LoadAll("Genres", typeof(Genre)).Cast<Genre>().ToArray()
            };
        }

        public Genre GetGenreWithName(string genreName) {
            return genres.FirstOrDefault(g => g.name == genreName);
        }

    }
    
}