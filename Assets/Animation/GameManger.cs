using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    Wizard wizard;
    PlayerControl plyr;
    public Collider2D Collider2D;

    public GameObject win;

    private void Start()
    {
        win.SetActive(false);
    
        wizard = GameObject.FindGameObjectWithTag("Enemy").gameObject.GetComponent<Wizard>();
        plyr = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerControl>();
    }
    private void FixedUpdate()
    {
        if (wizard.die==true)
        {
            Collider2D.isTrigger = true;
            plyr.Speed = 0;
            plyr.anim.SetTrigger("Happy");
            StartCoroutine(Active());
        }
    }
    IEnumerator Active()
    {
        yield return new WaitForSeconds(2);
        win.SetActive(true);
    }
}
