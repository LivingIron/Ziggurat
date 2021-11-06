using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEyes : MonoBehaviour
{

    public GameObject Trigger;
    public GameObject Eyes;
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(Trigger.GetComponent<BoxCollider>());
            Destroy(Eyes);
        }
    }
}
