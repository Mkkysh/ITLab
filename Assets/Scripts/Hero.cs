using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public Camera camera;
    
    [SerializeField]float speed = 10;
    [SerializeField]float jumpSpeed = 50;
    [SerializeField]float sensivity = 5;

    private bool isGround;

    Quaternion startingRotation;
    float rotHor;
    float rotVer;

    void Start()
    {
        startingRotation = transform.rotation;
    }

    
    void FixedUpdate()
    {
        Walk();
        Jump();
        CameraRotation();
    }

    float Hor()
    {
        float hor = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        return hor;
    }

    float Ver()
    {
        float ver = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        return ver;
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
        //camera.transform.rotation = startingRotation*RotHor()*transform.rotation;
        Quaternion q = startingRotation*transform.rotation*RotHor();
        q.z = 0;
        camera.transform.rotation = q;
        transform.rotation = startingRotation*RotVer();
    }
 
    void Walk()
    {
        transform.Translate(new Vector3(Hor(),0,Ver()));
    }                  

    void Jump()
    {
        if(isGround)
        {
            float jump = Input.GetAxis("Jump")*Time.deltaTime*jumpSpeed;
            GetComponent<Rigidbody>().AddForce(jump*transform.up,ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Ground")
            isGround = true;
    }

    private void OnCollisionExit(Collision other) 
    {
         if(other.gameObject.tag == "Ground")
            isGround = false;
    }
 
}