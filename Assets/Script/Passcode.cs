using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    string Code = "123";
    string Nmr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nmr = Nmr + Numbers;
        UiText.text = Nmr;

    }
    public void Enter()
    {
        if (Nmr == Code)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Delete()
    {
        NrIndex++;
        Nmr = null;
        UiText.text = Nmr;  
    }
}