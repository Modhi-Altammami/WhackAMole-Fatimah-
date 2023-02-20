using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;


public class MoleManeger : MonoBehaviour
{


    public static MoleManeger instance;
    Transform[] moles = new Transform[8];
    public GameObject Plane;
    
    [SerializeField]
    private TextMeshProUGUI TextScore;
    [SerializeField]
    private TextMeshProUGUI FinalScore;
    [SerializeField]
    private TextMeshProUGUI TextGameTimer;
    [SerializeField]
    private GameObject GameOver;
    [SerializeField]
    private GameObject Hammer;

    private int Score = 0;
    private float GameTimer = 40f;
    private float Timer = 1.5f;

    void Awake()
    {
      
        if (instance== null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }


    void Start()
    {
        Cursor.visible = false;

        //get all moles in one array & subsicribe to moleclicked event in each mole
        for (int i=0; i<8; i++) {

            moles[i] = Plane.transform.GetChild(i);
            moles[i].GetComponent<Mole>().MoleClicked += AddScore;
        }
        

    }

   
    void Update()
    {
        GameTimer -= Time.deltaTime;
        TextGameTimer.text = "Time Left : "+GameTimer.ToString("0:00s");
        Timer -= Time.deltaTime;



        //game end
        if(GameTimer <= 0 )
        {
            //move down all moles
            for (int i = 0; i < 8; i++)
            {
                    moles[i].GetComponent<Mole>().SetClicked(true); 
            }

            //activate gameover scene and send the score
            FinalScore.text = "Score : "+Score.ToString();
            GameOver.transform.localScale = Vector3.zero;
            GameOver.SetActive(true);
            LeanTween.scale(GameOver, Vector3.one, 1f).setEaseOutBounce();
           

            //deactivate objects
            Hammer.SetActive(false);
            gameObject.SetActive(false);
        }

        if(Timer <= 0)
        {
            Timer = 1.5f;
            ChangeRandomlay();
        }

    }

    void ChangeRandomlay()
    {
      
           for(int i = 0;i<4;i++)
          {
            int index = Random.Range(0, 8);
            if (moles[index].GetComponent<Mole>().Clicked)
            {
                moles[index].GetComponent<Mole>().SetClicked(false);
            }
            else
            {
                moles[index].GetComponent<Mole>().SetClicked(true);
            }

          }                   
    }

    void AddScore()
    {
        Score++;
        TextScore.text = "Score : "+Score.ToString();     
    }

   
}
