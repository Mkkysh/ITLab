// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Hero2D : MonoBehaviour
// {
    
//     [SerializeField]float speed = 10;
//     [SerializeField]float jumpSpeed = 50;

//     //public Hero h;

//     Rigidbody2D rb;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     // void SwitchGameMode()
//     // {
//     //     if(Input.GetButtonDown("DoSomething"))
//     //         h.SetGameMode();
//     // }

//     float Hor2D()
//     {
//         float hor = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
//         return hor;
//     }

//     void Walk2D()
//     {
//         transform.Translate(new Vector3(Hor2D(),0,0));
//     }             

//     void Update()
//     {
//         if(!h.gameMode3D)
//         {
//             Walk2D();
//         }
//     }
// }
