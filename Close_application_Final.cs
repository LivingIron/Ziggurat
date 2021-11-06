using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_application_Final : MonoBehaviour
{
 
    private IEnumerator EndITTT()
    {
        yield return new WaitForSeconds(35f);

        Debug.Log("Exited");
        Application.Quit();
    }

    void Start()
    {
        StartCoroutine(EndITTT());
    }

   
}
