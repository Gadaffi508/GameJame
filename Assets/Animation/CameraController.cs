using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _target;
    bool zoom = false;
    public float zoomSpped=5;
    public Transform _computer;
    AnimationControl player;

    private void Start()
    {
        StartCoroutine(Zoom());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimationControl>();
    }

    private void LateUpdate()
    {
       
        if (transform.position.x>=0)
        {
            transform.position = new Vector3(0,transform.position.y,-10);
        }
        if (zoom)
        {
            GetComponent<Camera>().orthographicSize = zoomSpped;
            zoomSpped = zoomSpped - Time.deltaTime;
            transform.position = new Vector3(_target.position.x,_target.transform.position.y, -10);
            if (zoomSpped<=2)
            {
                zoomSpped = 2;
            }
        }
        if (player.sidCom==true)
        {
            StartCoroutine(ZoomChalnge());
            GetComponent<Camera>().orthographicSize = zoomSpped;
            zoomSpped = zoomSpped - Time.deltaTime;

            transform.position = new Vector3(_computer.position.x, _computer.transform.position.y, -10);
            if (zoomSpped <= 0.1)
            {
                zoomSpped = 0.1f;
            }
        }
    }
    IEnumerator Zoom()
    {
        yield return new WaitForSeconds(2);
        zoom = true;
    }
    IEnumerator ZoomChalnge()
    {
        yield return new WaitForSeconds(1);
        zoom = false;
    }
}
