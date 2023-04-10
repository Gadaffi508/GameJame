using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float radius;
    public float Force;
    public LayerMask LayerHit;
    Collider2D[] rayInfo;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void explode()
    {
        rayInfo = Physics2D.OverlapCircleAll(transform.position, radius, LayerHit);

        foreach (Collider2D ray in rayInfo)
        {
            Vector2 Direction = ray.transform.position - transform.position;
            ray.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            explode();
            rayInfo = Physics2D.OverlapCircleAll(transform.position, radius, LayerHit);
            foreach (Collider2D player in rayInfo)
            {
                player.GetComponent<PlayerControl>().TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }
}
