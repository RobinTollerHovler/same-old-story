using Core.People;
using Core.Roles;
using SameOldStory.UI.Menus;
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
        
        private AddRoleButtonNode node;
        private RoleInformationTextComponent roleInformationTextComponent;
        
        private void Awake() {
            node = GetComponentInChildren<AddRoleButtonNode>();
            roleInformationTextComponent = GetComponentInChildren<RoleInformationTextComponent>();
        }

        public void Hide() {
            foreach(IMenu menu in GetComponentsInChildren<IMenu>()) menu.Close();
            node?.gameObject.SetActive(false);
        }

        public void Show(Actor attachedActor = null, Role attachedRole = null) {
            roleInformationTextComponent?.SetText(attachedRole?.RoleTitle ?? "Add role");
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
        
    }
    
}