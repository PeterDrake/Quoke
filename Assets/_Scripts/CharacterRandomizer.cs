using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    //[RequireComponent(typeof(ThirdPersonCharacter))]
    public class CharacterRandomizer : MonoBehaviour
    {
        private Transform player;
        private SkinnedMeshRenderer[] characterArray;
        private Transform character;
        private Object[] materialArray;
        private Material material;

        // Start is called before the first frame update
        void Start()
        {
            player = transform.GetComponent<Transform>();
            character = player.Find("Character");
            print(character.name);
            characterArray = character.GetComponentsInChildren<SkinnedMeshRenderer>(true);
            print(characterArray[0].name);
            characterArray[Random.Range(0, characterArray.Length-1)].gameObject.SetActive(true);

            /*
            int characterCount = m_Character.transform.GetChild(0).childCount;
            //set random character object to active
            characterArray = new GameObject[characterCount];
            for (int i = 0; i < characterCount; i++)
            {
                characterArray[i] = m_Character.transform.GetChild(0).GetChild(i).gameObject;
            }
            character = characterArray[Random.Range(0, characterCount-1)].gameObject;
            character.SetActive(true);
            */

            //apply random texture from Resources folder
            //materialArray = AssetDatabase.LoadAllAssetsAtPath("Assets/POLYGONCityCharacters/Materials/*");
            //material = (Material)materialArray[Random.Range(0, materialArray.Length-1)];
            //character.GetComponent<Renderer>().material = material;
        }
    }
}
