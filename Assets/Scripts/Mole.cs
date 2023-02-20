using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mole : MonoBehaviour
{

    public event Action MoleClicked;
    public bool Clicked = false;
 
    private float yPositionMax=1.7f;
    private float yPositionMin = 0.9f;
    private Vector3 Position;
    private float speed=3;
    private Collider co;
  


    void Start()
    {
        
        Position = gameObject.transform.position;
        co = GetComponent<CapsuleCollider>();
    }

   
    void Update()
    {
        if (Clicked)
        {
            if (gameObject.transform.position.y > yPositionMin)
            {
                MoveDown();
            }else
            {
                gameObject.transform.position = new Vector3(Position.x, yPositionMin, Position.z);
            }
        
        }else
        {
            if(gameObject.transform.position.y < yPositionMax)
            {
                MoveUp();
            }
            else
            {
                gameObject.transform.position = new Vector3(Position.x, yPositionMax, Position.z);
            }
          
        }
    }

    void MoveUp()
    {
       transform.Translate(Vector3.up * speed * Time.deltaTime);
       
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

    //the molemanager will use it
    public void SetClicked(bool flag)
    {
       
        Clicked = flag;

        //turn on the collider
        if (!flag) { co.enabled = true; }
    }

    public void Hit()
    {
        
            Clicked = true;

            //tell the manager about the click
            MoleClicked?.Invoke();

            //turn off the collider
            co.enabled = false;
        
    }

}
