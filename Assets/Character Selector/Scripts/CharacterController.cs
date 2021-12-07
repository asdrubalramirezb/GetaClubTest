using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    int character;
    public GameObject[] myPrefabs;
    void Awake()
    {
       character = CharacterSelector.character;
       myPrefabs[character].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
