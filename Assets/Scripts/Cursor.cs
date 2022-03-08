using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor: MonoBehaviour
{
    Quaternion startingRotation;
    float rotHor;
    float rotVer;
    [SerializeField]float sensivity = 5;
    Hero hero;
   
    void Start()
    {
        startingRotation = transform.parent.rotation;
        hero =  GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
    }

    void Update()
    {
        if(!hero.boxWalkig)
            CameraRotation();
    }

    Quaternion RotHor()
    {
        rotHor += Input.GetAxis("Mouse X")*sensivity;
        Quaternion rotX = Quaternion.AngleAxis(-rotVer,Vector3.right);
        return rotX;
    }

    Quaternion RotVer()
    {
        rotVer += Input.GetAxis("Mouse Y")*sensivity;
        rotVer = Mathf.Clamp(rotVer,-60,60);
        Quaternion rotY = Quaternion.AngleAxis(rotHor,Vector3.up);
        return rotY;
    }

    void CameraRotation()
    {
        transform.parent.rotation = startingRotation*transform.parent.parent.rotation*RotHor();
        transform.parent.parent.rotation = startingRotation*RotVer();
    }
}
