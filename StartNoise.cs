using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNoise : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource ASource;
    public GameObject Trigger;
    public float volume;


    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Destroy(Trigger.GetComponent<BoxCollider>());
        ASource.volume = volume;
        ASource.loop = true;
        ASource.Play();
       
    }
}
