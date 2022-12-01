using Core.People;
using Core.Roles;
using SameOldStory.UI.Menus;
using TMPro;
using UI.Windows.Specifics.ScriptCreator.Roles;
using UnityEngine;
using UnityEngine.UI;

namespace SameOldStory.UI.Windows.Specifics {
    
    public class RoleThumbnail : MonoBehaviour {
        
        [SerializeField] private Image face;
        [SerializeField] private Image eyes;
        [SerializeField] private Image nose;
        [SerializeField] private Image mouth;
        [SerializeField] private Image hair;
        [SerializeField] private GameObject plusSymbol;
        [SerializeField] private TextMeshProUGUI unavailable;
        
        private AddRoleButtonNode node;
        private RoleInformationTextComponent roleInformationTextComponent;
        
        private void Awake() {
            node = GetComponentInChildren<AddRoleButtonNode>();
            roleInformationTextComponent = GetComponentInChildren<RoleInformationTextComponent>();
            Debug.Log(roleInformationTextComponent);
        }

        public void Hide() {
            foreach(IMenu menu in GetComponentsInChildren<IMenu>()) menu.Close();
            node?.gameObject.SetActive(false);
            unavailable.gameObject.SetActive(false);
        }

        public void Show(Actor attachedActor = null, Role attachedRole = null) {
            unavailable.gameObject.SetActive(false);
            roleInformationTextComponent?.SetText(attachedRole?.RoleTitle ?? "Add role");
            if(attachedActor != null) roleInformationTextComponent?.SetText($"{attachedActor.Name} as:\n{attachedRole?.RoleTitle}");
            plusSymbol.SetActive(!attachedRole);
            face.sprite = attachedActor?.Face.FaceType;
            eyes.sprite = attachedActor?.Face.Eyes;
            nose.sprite = attachedActor?.Face.Nose;
            mouth.sprite = attachedActor?.Face.Mouth;
            hair.sprite = attachedActor?.Face.HairStyle;
            eyes.color = attachedActor?.Face.Eyes ? Color.white : Color.clear;
            mouth.color = attachedActor?.Face.LipColor ?? Color.clear;
            hair.color = attachedActor?.Face.HairColor ?? Color.clear;
            nose.color = attachedActor?.Face.HairColor ?? Color.clear;
            face.color = attachedActor?.Face.SkinTone ?? Color.clear;
            node?.gameObject.SetActive(true);
        }

        public void ShowUnavailable() {
            unavailable.gameObject.SetActive(true);
        }
        
    }
    
}