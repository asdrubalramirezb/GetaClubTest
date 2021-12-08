using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider col;

    
    Text scoreText;

    public static int score;



    private void Awake()
    {
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Start() {
        
        
        score = 0;
    }
     void OnTriggerEnter(Collider other) {
         Debug.Log("score");
         if (other.name == "BirdObj"){
         score++;
         }
         scoreText.text = score.ToString();
     }

}
