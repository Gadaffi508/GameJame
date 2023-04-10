using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraForMe : MonoBehaviour
{
    public Transform target;
    public MyPlayerController playerController;

    
   
    public Transform target2;
    public Transform target3;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MyPlayerController>();
    }

    private void LateUpdate()
    {

        if(playerController.focus==true ) 
        {
            transform.position = new Vector3(Mathf.Clamp(target2.position.x, -0.4f, 50), transform.position.y, -5);
        }

        if(playerController.focus==false && playerController.focus2==false ) 
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, -0.4f, 63), transform.position.y, -5);
        }

        if (playerController.focus2==true)
        {
            transform.position = new Vector3(Mathf.Clamp(target3.position.x, -0.4f, 50), transform.position.y, -5);
        }
       
        
    }
}
