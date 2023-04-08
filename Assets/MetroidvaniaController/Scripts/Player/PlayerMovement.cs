using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;

	public ÝtemsManager[] envanter;

    [SerializeField] private float radius = 1.5f; // Yuvarlýðýn yarýçapý
    [SerializeField] private int segments = 32; // Yuvarlýðýn kenar sayýsý

    public LayerMask detectionLayer;
    private Collider2D[] detectedObjects;

	public GameObject Envanter;
    private bool panelOpen = false;
    public float delayTime = 1f;
    //bool dashAxis = false;

    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			dash = true;
		}

		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/

	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;

        detectedObjects = Physics2D.OverlapCircleAll(transform.position, radius, detectionLayer);

        if (detectedObjects.Length > 0)
        {
			Envanter.SetActive(true);
            panelOpen = true;
        }
		else if(detectedObjects.Length <= 0)
		{
            Envanter.SetActive(false);
        }
    }
	public void AddIttems(Item item)
	{
		for (int i = 0; i < envanter.Length; i++)
		{
			if (envanter[i].isEmpty)
			{
				envanter[i].AddItems(item);
				break;

            }
		}
	}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; // Yuvarlýðýn rengi
        Gizmos.DrawWireSphere(transform.position, radius); // Yuvarlýðýn merkezi ve yarýçapý

        // Yuvarlýðýn kenarlarýný çizmek için döngü kullanýyoruz
        for (int i = 0; i < segments; i++)
        {
            float angle = i * Mathf.PI * 2f / segments;
            Vector2 pointA = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
            Vector2 pointB = new Vector2(Mathf.Sin(angle + Mathf.PI * 2f / segments), Mathf.Cos(angle + Mathf.PI * 2f / segments)) * radius;
            Gizmos.DrawLine(transform.position + (Vector3)pointA, transform.position + (Vector3)pointB);
        }
    }
}
