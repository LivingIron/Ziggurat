using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{

    public CharacterController cc;
    public AudioSource step;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.isGrounded == true && cc.velocity.magnitude>0f && step.isPlaying == false)
        {
            step.volume = Random.Range(0.09f, 0.2f);
            step.pitch = Random.Range(0.8f, 1);
            step.Play();
        }
        
    }
}
