using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject canvas;
    Rigidbody2D rb;
    public float Speed;
    public float jumpForce;
    bool jump=true;
    float X;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(X*Time.deltaTime*Speed,0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            jump = true;
        }
    }

   
}
