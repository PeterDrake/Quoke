using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class CharacterRandomizer : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character;
        private GameObject[] characterArray;
        private GameObject character;
        private Object[] materialArray;
        private Material material;

        // Start is called before the first frame update
        void Start()
        {
            m_Character = GetComponent<ThirdPersonCharacter>();
            int characterCount = m_Character.transform.GetChild(0).childCount;
            //set random character object to active
            characterArray = new GameObject[characterCount];
            for (int i = 0; i < characterCount; i++)
            {
                characterArray[i] = m_Character.transform.GetChild(0).GetChild(i).gameObject;
            }
            character = characterArray[Random.Range(0, characterCount)].gameObject;
            character.SetActive(true);
            //apply random texture from Resources folder
            materialArray = Resources.LoadAll("CharacterMaterials", typeof(Material));
            material = (Material)materialArray[Random.Range(0, materialArray.Length)];
            character.GetComponent<Renderer>().material = material;
        }
    }
}
