using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HataMesajiGöster : MonoBehaviour
{
    public GameObject hataMesaji1;
    public GameObject hataMesaji2;
    public GameObject hataMesaji3;
    public GameObject hataMesaji4;  
    public GameObject hataMesaji5;
    public GameObject hataMesaji6;
    public GameObject hataMesaji7;  
    public GameObject hataMesaji8;
    public GameObject hataMesaji9;
    public GameObject hataMesaji10; 
    public GameObject hataMesaji11;
    public GameObject hataMesaji12;
    public GameObject hataMesaji13;
    public GameObject hataMesaji14;
    public GameObject hataMesaji15;
    public GameObject hataMesaji16;
    public GameObject hataMesaji17;

    public AudioSource errorSound;
    public AudioClip errorClip;
    public AudioClip clickClip;

    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;

    public GameObject startButton;


    



    public IEnumerator mesajGöster()
    {
        while (true)
        { 
            //---------SAHNELERİN AKTİF OLMALARI//-----------------//

            yield return new WaitForSecondsRealtime(3f);
            scene1.SetActive(false);
            scene2.SetActive(true);
            yield return new WaitForSecondsRealtime(1.5f);
            scene2.SetActive(false);
            scene3.SetActive(true);
            yield return new WaitForSecondsRealtime(1f);
            errorSound.PlayOneShot(clickClip);
            yield return new WaitForSecondsRealtime(0.1f);
            errorSound.PlayOneShot(clickClip);
            yield return new WaitForSecondsRealtime(1.5f);
             
            //--------------HATA MESAJLARI----------------------------//

            hataMesaji1.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji2.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji3.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);       
            hataMesaji4.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji5.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);        
            hataMesaji6.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji7.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f); 
            hataMesaji8.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);  
            hataMesaji9.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji10.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji11.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji12.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji13.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji14.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji15.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji16.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(0.2f);
            hataMesaji17.SetActive(true);
            errorSound.PlayOneShot(errorClip);
            yield return new WaitForSecondsRealtime(1.5f);
            startButton.SetActive(true);
            yield break;
        }

    }

    private void Start()
    {
        StartCoroutine("mesajGöster");
    }
}
