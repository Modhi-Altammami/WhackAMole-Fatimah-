using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    public Camera CamMain;
    public ParticleSystem partical;
    private Vector3 TargetPos;
    private Ray ray;
    private float yPos;
    
    void Start()
    {
     
      CamMain = Camera.main;
      yPos = transform.position.y;
     
    }
    void Update()
    {

        TargetPos = CamMain.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3));
        gameObject.transform.position = TargetPos;

        ray = CamMain.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit HitInfo))
        {
            if (HitInfo.collider.TryGetComponent<Mole>(out Mole script))
            {
               
                if (GetYVelcity() > 10) //if the hit is "verticlly strong" we will consider it.
                {
                    gameObject.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, HitInfo.transform.position.z);
                    gameObject.GetComponent<AudioSource>().Play();
                   // partical.SetActive(true);
                    partical.Play();
                    partical.transform.position = new Vector3(HitInfo.transform.position.x, HitInfo.transform.position.y, HitInfo.transform.position.z);
                    script.Hit();
                }
             
                
            }
        }
        
     
    } 
    
    float GetYVelcity()
    {
        //the velocity equation v=d/t;
        float yVelocity= (yPos- transform.position.y)/Time.deltaTime;
        yPos = transform.position.y;
      
        return yVelocity;
    }
}
