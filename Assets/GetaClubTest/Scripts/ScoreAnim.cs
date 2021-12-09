using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreAnim : MonoBehaviour
{
    // Start is called before the 
    Slider scoreSlider;
    public GameObject panelWin;
    Text scoreText;
    bool win;
    void Start()
    {
        scoreSlider = GameObject.Find("scoreSlider").GetComponent<Slider>();
        scoreSlider.value = 0;

    }

    // Update is called once per frame
    void Update()
    {
         scoreSlider.value = ScoreControl.score;
         if(scoreSlider.value >= 40)
         {
             panelWin.SetActive(true);
             scoreSlider.value = 40;
             StartCoroutine( restartScene());
         }
        
    }

    IEnumerator restartScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("level1");
    }
}
