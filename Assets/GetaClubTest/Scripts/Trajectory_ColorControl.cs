using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory_ColorControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dotPrefab;
    SpriteRenderer m_SpriteRenderer;
     int character;


    void Awake(){

        character = CharacterSelector.character;
        m_SpriteRenderer = dotPrefab.GetComponent<SpriteRenderer>();
        if(character == 0){
            m_SpriteRenderer.color = Color.black;
        }
         if(character == 1){
            m_SpriteRenderer.color = Color.white;
        }
         if(character == 2){
            m_SpriteRenderer.color = Color.red;
         }
    }
   

}
