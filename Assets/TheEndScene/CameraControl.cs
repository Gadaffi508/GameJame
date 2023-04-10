using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    public Transform _firstTarget;
    public float zoomSpped = 0.13f;
    bool zoom = false;

    private void Start()
    {
        
    }
    private void LateUpdate()
    {

        zoomSpped = zoomSpped + Time.deltaTime;
        GetComponent<Camera>().orthographicSize = zoomSpped;
        if (zoomSpped>=5)
        {
            zoomSpped = 5;
            zoom = true;
        }
        if (zoom)
        {
            transform.position = new Vector3(_firstTarget.position.x, _firstTarget.transform.position.y, -10);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12, 12), transform.position.y, -10);
        }
    }
}
