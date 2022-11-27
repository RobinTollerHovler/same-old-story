using SameOldStory.Core.Data;
using UnityEngine;

namespace Core.Roles {
    
    [CreateAssetMenu(fileName = "New Role", menuName = "Data/Role")]
    public class Role : UnlockableStudioData {

        [SerializeField] private string roleTitle;
        [SerializeField] private Genre[] fittingGenres;
        [SerializeField] private Genre[] unfittingGenres;

    }
    
}