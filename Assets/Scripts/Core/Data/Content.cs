using UnityEngine;

namespace SameOldStory.Core.Data {
    
    [CreateAssetMenu(fileName = "New Content", menuName = "Data/Content")]
    public class Content : UnlockableStudioData {

        [Header("Content options")]
        [SerializeField] private string description;
        [SerializeField] private int majorRoles;
        [SerializeField] private int minorRoles;

    }
    
}
