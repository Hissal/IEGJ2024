using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwapper : MonoBehaviour
{
    public static CharacterSwapper Instance;

    [SerializeField] private GameObject lightWorld;
    [SerializeField] private GameObject darkWorld;

    private void Awake()
    {
        Instance = this;
    }

    public enum Character
    {
        Child,
        Teddy
    }

    [System.Serializable]
    public struct CharacterStruct
    {
        public Character character;
        public CharacterBase characterScript;
    }

    [SerializeField] private CinemachineVirtualCamera virtualCam;
    [SerializeField] private List<CharacterStruct> characters;
    private CharacterBase currentCharacterScript;

    public Character currentCharacter { get; private set; }

    private void Start()
    {
        SwapCharacter(Character.Child);
    }

    public void SwapCharacter(Character characterToSwapTo)
    {
        foreach (CharacterStruct character in characters)
        {
            if (character.character == characterToSwapTo)
            {
                currentCharacter = character.character;
                // do things with characterStruct
                if (currentCharacterScript != null) currentCharacterScript.SwapOff();
                character.characterScript.SwapTo();
                currentCharacterScript = character.characterScript;
                virtualCam.Follow = character.characterScript.transform;
                virtualCam.LookAt = character.characterScript.transform;
                return;
            }
        }

        Debug.LogWarning("Could not find a character to swap to");
    }

    public void SwapWorld(Character character)
    {
        switch (character)
        {
            case Character.Child:
                lightWorld.SetActive(false);
                darkWorld.SetActive(true);
                break;
            case Character.Teddy:
                lightWorld.SetActive(true);
                darkWorld.SetActive(false);
                break;
            default:
                break;
        }
    }
}
