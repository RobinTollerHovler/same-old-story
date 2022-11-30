using System.Linq;
using SameOldStory.Core.Data;
using UnityEngine;

namespace SameOldStory.Core.Studios {

    public class DefaultStudioInitializer : MonoBehaviour {

        [SerializeField] private int actorWagePerFameLevel = 0;
        [SerializeField] private int movieProfitBase;
        [SerializeField] private int actorHiringCost;
        [SerializeField] private bool printRoleInfo;

        private void Awake() {
            Studio.InitializeNewStudio(
                actorWagePerFameLevel,
                movieProfitBase,
                actorHiringCost
            );
            if (printRoleInfo) PrintRoleInfo();
        }

        private void PrintRoleInfo() {
            foreach (Genre g in Studio.Current.AvailableGenres) {
                Debug.Log($"GENRE: {g.Name} +{Studio.Current.AvailableRoles.Where(role => role.FittingGenres.Contains(g)).Count()} -{Studio.Current.AvailableRoles.Where(role => role.UnfittingGenres.Contains(g)).Count()}");
            }
        }
    }
    
}