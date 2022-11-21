using System.Linq;
using SameOldStory.Core.Data.People;
using SameOldStory.Input.Unity;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace People {
    
    public class PersonRandomizer : MonoBehaviour {

        [SerializeField] private Image face;
        [SerializeField] private Image leftEye;
        [SerializeField] private Image rightEye;
        [SerializeField] private Image nose;
        [SerializeField] private Image mouth;
        [SerializeField] private Image hair;
        
        private void Start() {
            UnityInputSystem unityInputSystem = new UnityInputSystem();
            unityInputSystem.Studio.Enable();
            unityInputSystem.Studio.RandomPerson.started += newPerson;
        }

        private void newPerson(InputAction.CallbackContext context) {
            PeopleTemplate[] randomPeopleTemplates = Resources.LoadAll("PeopleTemplates", typeof(PeopleTemplate)).Cast<PeopleTemplate>().ToArray();
            if (randomPeopleTemplates.Length == 0) return;
            PeopleTemplate randomPeopleTemplate = randomPeopleTemplates[Random.Range(0, randomPeopleTemplates.Length)];
            face.sprite = randomPeopleTemplate.RandomFace;
            face.color = randomPeopleTemplate.RandomSkinTone;
            Sprite eyes = randomPeopleTemplate.RandomEyes;
            leftEye.sprite = eyes;
            rightEye.sprite = eyes;
            nose.sprite = randomPeopleTemplate.RandomNose;
            mouth.sprite = randomPeopleTemplate.RandomMouth;
            hair.sprite = randomPeopleTemplate.RandomHairStyle;
            hair.color = randomPeopleTemplate.RandomHairColor;
        }
        
    }
    
}