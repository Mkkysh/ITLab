using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{

    GameMasterScript gameMaster;
    
    void Start()
    {
        gameMaster =  GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMasterScript>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Hero")
            gameMaster.avalibale = true;    
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Hero")
            gameMaster.avalibale = false;
    }

}
