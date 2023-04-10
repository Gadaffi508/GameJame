using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyPlayerController : MonoBehaviour
{
    public GameObject canvas;
    CameraForMe cam;
    Rigidbody2D rb;
    public float Speed;
    public float jumpForce;
    bool jump = true;
    float X;
    Vector2 _X = new Vector2(1, 1);
    Animator anim;

    public bool focus = false;
    public GameObject puzzle2;
    public Main _main;
    public bool focus2 = false;
    public bool bittimi2=false;
    public GameObject not;
    

 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<CameraForMe>();
       
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
        if (bittimi2==true)
        {
            if (_main.bittimi == true)
            {
                puzzle2.SetActive(false);
                Speed = 5;
                focus2 = false;
            }
        }



    }
    private void FixedUpdate()
    {

        transform.Translate(new Vector2(X * Time.deltaTime * Speed, 0));
        if (X >= 0)
        {
            transform.localScale = _X;
            _X.x = 1;
        }
        else if (X < 0.01f)
        {
            transform.localScale = _X;
            _X.x = -1;
        }
        anim.SetFloat("Speed", Mathf.Abs(X));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            jump = true;
            anim.SetBool("Jump", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Puzzleci"))
        {
            canvas.SetActive(true);

            Speed = 0;
            focus = true;
        }
        if (other.gameObject.CompareTag("Puzzleci2"))
        {
            
            puzzle2.SetActive(true);
            _main = GameObject.FindGameObjectWithTag("Main").gameObject.GetComponent<Main>();

           
            Speed = 0;
            focus2 = true;
        }

        if (other.gameObject.CompareTag("Paper"))
        {
            
            not.SetActive(true);
            StartCoroutine(DisableNotification());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator DisableNotification()
    {
        yield return new WaitForSecondsRealtime(5);
        not.SetActive(false);
    }
}

   

