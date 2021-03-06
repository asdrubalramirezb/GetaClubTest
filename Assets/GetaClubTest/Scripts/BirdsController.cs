using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;



public class BirdsController : MonoBehaviour
{
    #region Singleton class: GameManager

    public static BirdsController Instance;

    #endregion

    Camera cam;

    BirdEntityBase3 birdEntityEntity;

    public Trajectory trajectory;
    public float _pushForce = 4f;
    public float Timeforrespawn = 3f;
    public float timeForDisable = 3f;

    public float TimeForRespawn => Timeforrespawn;

    public bool _isDragging;
    public bool Launched;
    public bool disappeared;
    public bool midFlyAPplied;

    public Vector3 startPoint;
    public Vector3 endPoint;
    public Vector3 direction;
    private Vector3 force;
    public float distance;

    private Vector3 initPos;
    private Vector3 initScale;
    private Quaternion initRot;
    public GameObject[] myPrefabs;

    [Header("Text Asset")]
    public TextAsset wordsSource;

    [Header("List of Words")]
    public List<string> words = new List<string>();
    int character;
    public Rigidbody rb;
    int count;
    private Text timerText;
    public float time;
    Image BirdCharacter;
    public Sprite[] spriteBirds;
    private Text BirdText;

    //---------------------------------------
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       words = wordsSource.text.Split(',').ToList();
       BirdCharacter = GameObject.Find("BirdCharacter").GetComponent<Image>();
       BirdText = GameObject.Find("BirdText").GetComponent<Text>();
       character = CharacterSelector.character;
       myPrefabs[character].SetActive(true);

        if (birdEntityEntity == null)
            birdEntityEntity = GetComponentInChildren<BirdEntityBase3>();
    }

    void Start()
    {
        count = 0;
        rb =  GetComponentInChildren<Rigidbody>();
        cam = Camera.main;
        birdEntityEntity.DisableBehave();
        initPos = birdEntityEntity.transform.position;
        initRot = birdEntityEntity.transform.rotation;
        initScale = birdEntityEntity.transform.localScale;
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        BirdCharacter.sprite = spriteBirds[character]; 
        BirdText.text = words[character];


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Launched)
        {
            _isDragging = true;
            OnDragStart();
        }
        else if (Input.GetMouseButtonDown(0) && Launched && !midFlyAPplied)
        {
            Debug.Log("aqui");
            birdEntityEntity.GetComponentInChildren<IMidFlyAble>().PerformMidFlyBehave();
            //birdEntityEntity.PerformMidFlyBehave();
            midFlyAPplied = true;
        }

        if (rb.velocity.y < 0 )
        {
            count ++; 
        }

        if ( count == 1){
           Debug.Log("instance");
           Vector3 actualPos = birdEntityEntity.transform.position;
           GameObject actualBird = myPrefabs[character];
           Halfway.instance.ExplotionSound();
           Halfway.instance.ExplotionBehave(actualPos);
           Halfway.instance.BirdTriplication( actualPos, actualBird, force);
           count++;
        }

        if (Input.GetMouseButtonUp(0) && !Launched)
        {
            _isDragging = false;
            OnDragEnd();
        }

        if (_isDragging)
        {
            OnDrag();
        }

        if (Launched)
        {
            // el tiempo no presenta un bien formato 
            //time += Time.deltaTime;

            //formato adecuado para el tiempo 
              int minutes = Mathf.FloorToInt(time/60);
              int seconds = Mathf.FloorToInt(time - minutes * 60f);
              string textTime = string.Format("{0:0}:{1:00}",minutes,seconds);
              time += Time.deltaTime;
              timerText.text = textTime;
            

            if (time >= timeForDisable && !disappeared)
            {
                // birdEntityEntity.DisappearBird();
                birdEntityEntity.GetComponentInChildren<IDisapperable>()?.DisappearBird();
                disappeared = true;
            }

            if (time >= Timeforrespawn)
            {
                birdEntityEntity.DisableBehave();
                ResetBird();
                time = 0;
                count = 0;
            }
        }


        // la variable text deberia inicializarse en el start, ya que cuando se hace en el update se esta inicializando en cada frame
        // lo cual ademas de ser innecesario podria generar unas malas practicas , seria bueno usar un nombre diferente para la variable, ya que text es un metodo 
        //text = GameObject.Find("Text (TMP)").GetComponent<TMP_Text>();
        //text.text = time.ToString();

    }

    public void ResetBird()
    {
        birdEntityEntity.transform.position = initPos;
        birdEntityEntity.transform.rotation = initRot;
        birdEntityEntity.transform.localScale = initScale;
        birdEntityEntity.AppearBird();
        Launched = false;
        disappeared = false;
        midFlyAPplied = false;
    }

    //-Drag--------------------------------------
    void OnDragStart()
    {
        birdEntityEntity.DisableBehave();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector3.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * _pushForce;

        //just for debug
        Debug.DrawLine(startPoint, endPoint);
        trajectory.UpdateDots(birdEntityEntity.movementCtrl.pos, force);
    }

    void OnDragEnd()
    {
        birdEntityEntity.MakeSound();

        //push the ball
        birdEntityEntity.movementCtrl.ActivateRb();

        birdEntityEntity.movementCtrl.Push(force);

        trajectory.Hide();

        Launched = true;
    }

    
}