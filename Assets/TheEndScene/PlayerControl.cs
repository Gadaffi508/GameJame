using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    public float jumpForce;
    bool jump = true;
    float X;
    Vector2 _X = new Vector2(1,1);
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }
    private void Update()
    {
        X = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
            jump = false;
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
        transform.Translate(new Vector2(X * Time.deltaTime * Speed, 0));
        if (X>=0)
        {
            transform.localScale = _X;
            _X.x = 1;
        }
        else if (X < 0.01f)
        {
            transform.localScale = _X;
            _X.x = -1;
        }
        anim.SetFloat("Speed",Mathf.Abs(X));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            jump = true;
            anim.SetBool("Jump", false);
        }
    }
}
