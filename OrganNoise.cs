using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganNoise : MonoBehaviour
{
    

   
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    private IEnumerator temp;
    public AudioSource source;
    public AudioClip clip;
    public AudioClip clipReverse;


    private IEnumerator TriggerNoises()
    {
       
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(1);
        source.PlayOneShot(clipReverse);
        yield return new WaitForSeconds(2);
        player.transform.position = respawnPoint.transform.position;
        yield break;
    }

   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (temp != null) StopCoroutine(temp);
            temp = TriggerNoises();
            StartCoroutine(temp);
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            
            source.Stop();
             StopAllCoroutines();
            source.volume = 1;
            
        }
        
    }

}
