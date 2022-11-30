using SameOldStory.Core.Data;
using UnityEngine;

namespace Core.Roles {
    
    [CreateAssetMenu(fileName = "New Role", menuName = "Data/Role")]
    public class Role : UnlockableStudioData {

        [SerializeField] private string roleTitle;
        [SerializeField] private string plural;
        [SerializeField] private string roleIndefiniteArticle;
        [SerializeField] private Genre[] fittingGenres;
        [SerializeField] private Genre[] unfittingGenres;

        public string RoleTitle => roleTitle;
        public string Plural => plural;
        public string IndefiniteArticle => roleIndefiniteArticle;
        public Genre[] FittingGenres => fittingGenres;
        public Genre[] UnfittingGenres => unfittingGenres;

    }
    
}