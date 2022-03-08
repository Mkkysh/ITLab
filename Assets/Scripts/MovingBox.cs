using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    Vector3 StartingPosition;
    GameMasterScript gameMaster;
    Hero hero;
    Transform posBoxTrigger;
    bool active = false;
    void Start()
    {
        gameMaster =  GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMasterScript>();
        hero =  GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
        posBoxTrigger = transform.GetChild(0);
        posBoxTrigger.position = new Vector3(posBoxTrigger.position.x,hero.transform.position.y, posBoxTrigger.position.z);
    }

    void Update()
    {
        if(hero.boxWalkig && active)
        {
            hero.gameObject.transform.rotation = transform.rotation;
            hero.gameObject.transform.position = new Vector3(posBoxTrigger.position.x,hero.transform.position.y, posBoxTrigger.position.z);
           
            if(Mathf.Approximately(Quaternion.Angle(hero.gameObject.transform.rotation, transform.parent.rotation), 0f))
                transform.parent.Translate(new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime*(float)4.84,0,Input.GetAxis("Vertical")*Time.deltaTime*(float)4.84));
            else if(Mathf.Approximately(Quaternion.Angle(hero.gameObject.transform.rotation, transform.parent.rotation), 180f))
                transform.parent.Translate(new Vector3(-Input.GetAxis("Horizontal")*Time.deltaTime*(float)4.84,0,-Input.GetAxis("Vertical")*Time.deltaTime*(float)4.84));
            else if(transform.localPosition.x > 0)        
                transform.parent.Translate(new Vector3(-Input.GetAxis("Vertical")*Time.deltaTime*(float)4.84,0,Input.GetAxis("Horizontal")*Time.deltaTime*(float)4.84));
            else
                transform.parent.Translate(new Vector3(Input.GetAxis("Vertical")*Time.deltaTime*(float)4.84,0,-Input.GetAxis("Horizontal")*Time.deltaTime*(float)4.84));
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Hero")
        {
            gameMaster.avalibaleBox = true; 
            active = true;  
        }
    }

    private void OnTriggerExit(Collider other) 
    {
         if(other.gameObject.tag == "Hero")
         {
            gameMaster.avalibaleBox = false;   
            active = false; 
         }
    }

}
