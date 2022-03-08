using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameMasterScript : MonoBehaviour
{

    public bool gameMode = true;
    public bool avalibale = false;
    public bool avalibaleBox = false;
    public bool boxWalkig = false;
    int location = 2;
    GameObject cameraContainer;
    
    void Start()
    {
        cameraContainer = GameObject.FindGameObjectWithTag("CameraContainer");
    }
    
    void Update()
    {
        CameraChecker();
    }

    void ChangeCamera(int index)
    {
        if(index > 0)
        {
            cameraContainer.transform.FindChild("CM vcam"+index).gameObject.GetComponent<CinemachineVirtualCamera>().Priority += 100;
        }
        else
            cameraContainer.transform.FindChild("CM vcam"+index*(-1)).gameObject.GetComponent<CinemachineVirtualCamera>().Priority -= 100;
    }

    public void ChangeMode()
    {
        if(!gameMode)
            ChangeCamera(location);
    }

   void CameraChecker()
    {
        if( 
            (!gameMode) &&
            ( Vector3.Distance((cameraContainer.transform.FindChild("CM vcam"+location).position),cameraContainer.transform.FindChild("Main Camera").position) < (float)0.01) &&
            cameraContainer.transform.FindChild("Main Camera").gameObject.GetComponent<Camera>().orthographic == false
        )
            cameraContainer.transform.FindChild("Main Camera").gameObject.GetComponent<Camera>().orthographic = true;
    }

}
