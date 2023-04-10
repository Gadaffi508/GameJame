using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;
    public float jumpForce;
    bool jump = true;
    float X;
    Vector2 _X = new Vector2(1,1);
   public  Animator anim;

    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemylayer;
    public int damage = 10;
    public float attackrate = 1.5f;
    public float nextAttackTime;

    public int health=100;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackrange;
            }
        }
    }
    private void FixedUpdate()
    {
       
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
    public void Attack()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position,attackrange,enemylayer);
        foreach (Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<Wizard>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmos()
    {
        if (attackpoint==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position,attackrate);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <=0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetTrigger("Die");
        Debug.Log("Öldüm");
    }
}
