using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetst2d3d : MonoBehaviour
{
    public Camera camera;
    Transform g; 
    public Hero h;
    
    void Start()
    {
        g = transform.parent.Find("LOCATE");
    }

    void Update()
    {
        
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            h.SetGameMode();
            //camera.transform.position = Vector3.Lerp(camera.transform.position,g.position,5*Time.deltaTime);
            camera.transform.position = g.position;
            camera.transform.rotation = transform.rotation;
            camera.orthographic = true;
            camera.orthographicSize = (float)0.7;
        }
    }
}
