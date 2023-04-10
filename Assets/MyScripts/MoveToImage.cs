using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveToImage : MonoBehaviour
{
    Camera cam;
    Vector2 baslangicPozisyonu;

    GameObject[] Kutular;
    int toplamParca = 3;
    int yerlestirelenParca;

    public GameObject canvas;
    public MyPlayerController player;

   

    


    private void OnMouseDrag()
    {
        Vector3 pozisyon = cam.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        pozisyon.z = 0;
        transform.position = pozisyon;
        

    }

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        baslangicPozisyonu = transform.position;

        Kutular = GameObject.FindGameObjectsWithTag("Kutu");
        player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<MyPlayerController>();
        
    }
    private void Update()
    {
        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            foreach (GameObject kutu in Kutular)
            {
                if (kutu.name == gameObject.name)
                {
                    float mesafe = Vector3.Distance(kutu.transform.position, transform.position);

                    if (mesafe<=1)
                    {
                        transform.position = kutu.transform.position;
                        yerlestirelenParca++;

                    }
                    else
                    {
                        transform.position = baslangicPozisyonu;
                        yerlestirelenParca--;
                    }
                    if(yerlestirelenParca==toplamParca)
                    {
                        canvas.SetActive(false);
                        player.Speed = 5;
                        player.focus = false;
                    }                    
                }
            }
        }
    }
}
