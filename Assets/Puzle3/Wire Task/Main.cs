using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public Main Instance;

    public int switchCount;
    public GameObject winText;
    private int onCount = 0;
    public bool bittimi = false;
    public MyPlayerController playerController;



    private void Start()
    {
        playerController=GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<MyPlayerController>();
    }


    private void Awake()
    {
        Instance = this;
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            winText.SetActive(true);
            bittimi = true;
            playerController.bittimi2 = true;

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
