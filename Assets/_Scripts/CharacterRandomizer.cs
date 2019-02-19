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
        private Material material;
        private Texture[] textureArray;
        private Texture texture;

        // Start is called before the first frame update
        void Start()
        {
            m_Character = GetComponent<ThirdPersonCharacter>();
            int characterCount = m_Character.transform.GetChild(0).childCount;
            characterArray = new GameObject[characterCount];
            for (int i = 0; i < characterCount; i++)
            {
                characterArray[i] = m_Character.transform.GetChild(0).GetChild(i).gameObject;
            }
            characterArray[Random.Range(0, characterCount)].gameObject.SetActive(true);
        }
    }
}
