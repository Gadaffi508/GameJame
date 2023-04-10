using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public int maxHealth = 100;
    public Animator anim;
    public GameObject fire;
    public Transform firePosition;
    public float Distance;
    private Transform Target;
    public float fireRate;
    private float nextTimeFireRate;
    public bool die=false;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    private void FixedUpdate()
    {
        RaycastHit2D enemyActive = Physics2D.Raycast(transform.position, -transform.right, Distance);

        if (enemyActive.collider != null)
        {
            Debug.DrawLine(transform.position, enemyActive.point, Color.red);
            if (Time.time>nextTimeFireRate)
            {
                nextTimeFireRate = Time.time+1/fireRate;
                anim.SetTrigger("Fire");
            }
        }
        if (enemyActive.collider == null)
        {
            Debug.DrawLine(transform.position, enemyActive.point, Color.green);
        }
    }
    public void Shoot()
    {
        GameObject firebul = Instantiate(fire, firePosition.position,Quaternion.identity);
        firebul.GetComponent<Rigidbody2D>().AddForce(transform.right*-500);
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
        //anim
        if (maxHealth <= 0)
        {
            maxHealth = 0;
            die = true;
            Die();

        }
    }

    void Die()
    { 
        Destroy(gameObject);
    }
}
