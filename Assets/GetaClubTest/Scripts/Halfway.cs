using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halfway : MonoBehaviour
{
    // Start is called before the first frame update
    public static Halfway instance;
	public GameObject fx_prefabs;
    GameObject  BirdController;
     public float Timeforrespawn = 3f;
     public float time;
     public List<GameObject> clones = new List<GameObject>();
     //GameObject[] clones;
	
    private void Awake()
    {
        instance = this;
        //Halfway.instance.ExplotionBehave();
    }
    void Start()
    {
         BirdController =GameObject.Find("BirdsCntroller");
    }

    public void ExplotionBehave(Vector3 Birdposition){
		
       Instantiate(fx_prefabs, Birdposition, Quaternion.identity);
 
    } 

     public void BirdTriplication(Vector3 Birdposition, GameObject bird){
         for (int i = 0; i<2; i++){
            GameObject cloneBird = Instantiate(bird);
            cloneBird.transform.SetParent(BirdController.transform);
            cloneBird.transform.position = Birdposition;
            clones.Add(cloneBird);
         }
         StartCoroutine(DestroyClones());
     }

     IEnumerator DestroyClones()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i<2; i++){
                    Destroy(clones[i]);
             }
            clones.Clear();
    }

}