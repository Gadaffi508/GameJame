using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator anim;
    int speed=3;
    bool walk=false;
    public bool sidCom=false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(StartScene());
    }
    private void FixedUpdate()
    {
        if (walk)
        {
            transform.position = new Vector2(transform.position.x + Time.deltaTime * speed, transform.position.y);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Computer"))
        {
            speed = 0;
            anim.SetBool("Come", true);

            sidCom = true;
        }
    }
    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("Walk",true);
        walk=true;
    }
}
