using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreAnim : MonoBehaviour
{
    // Start is called before the 
    public Slider scoreSlider;
    GameObject panelWin;
    float ScoreWin =  100;
    Text scoreText;
    void Start()
    {
        panelWin = GameObject.Find("panelWin");
        scoreSlider = GameObject.Find("scoreSlider").GetComponent<Slider>();
        scoreSlider.value = 0;
        panelWin.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log(ScoreControl.score);
         scoreSlider.value = ScoreControl.score;
         if(scoreSlider.value >= 50)
         {
            panelWin.SetActive(true);
         }
        
    }
}
