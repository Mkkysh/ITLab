using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    Vector3 cameraPos3D;
    
    void Start()
    {
        cameraPos3D = GameObject.Find("Main Camera").transform.position;
    }

    
    void Update()
    {
        
    }
}
