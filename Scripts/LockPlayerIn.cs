using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerIn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Trigger, terrainPopup,InvisWall;



    private IEnumerator LockIn()
    {
       
        
        yield return new WaitForSeconds(1);
        terrainPopup.transform.localPosition = new Vector3(153.27f, 151.11f, -102.86f);
        InvisWall.transform.localPosition = new Vector3(1.794806f, -33.6021f, -119.2408f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            StartCoroutine(LockIn());
            Destroy(Trigger.GetComponent<BoxCollider>());
        }
    }
}
