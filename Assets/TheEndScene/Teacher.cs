using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    public float jumpForce=5;
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //anim.SetBool("Jump", true);
        }
    }
}
