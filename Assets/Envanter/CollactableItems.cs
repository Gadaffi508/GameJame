using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollactableItems : MonoBehaviour
{
    public Item item;
    Transform itmngr;
    public float speed=5;
    bool comploted=false;
    public BoxCollider2D collider;

    private void Start()
    {
        itmngr = GameObject.FindGameObjectWithTag("items").gameObject.GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().AddIttems(item);
            comploted=true;
            collider.enabled=false;
            Destroy(gameObject,3f);
        }
    }
    private void FixedUpdate()
    {
        if (comploted)
        {
            transform.position = Vector2.MoveTowards(transform.position, itmngr.transform.position, speed * Time.deltaTime);
        }
    }
}
