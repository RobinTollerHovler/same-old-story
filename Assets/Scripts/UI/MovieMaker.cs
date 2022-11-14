using SameOldStory.Movies;
using TMPro;
using UnityEngine;

namespace SameOldStory.UI {
    
    public class MovieMaker : MonoBehaviour {

        [SerializeField] private TMP_InputField movieNameInputField;

        private Movie constructingMovie;

        public void SubmitMovieName() {
            constructingMovie = new Movie(movieNameInputField?.text);
            constructingMovie.Activate();
        }

    }
    
}