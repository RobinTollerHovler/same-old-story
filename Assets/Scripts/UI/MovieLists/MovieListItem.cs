using SameOldStory.Core;
using SameOldStory.Core.Movies;
using UnityEngine;

namespace UI.MovieLists {
    
    public class MovieListItem : MonoBehaviour, IRepresentMovie {
        
        public Movie Movie { get; set; }

    }
    
}