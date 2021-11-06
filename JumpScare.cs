using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform player,Spawn;
    public GameObject Trigger,terrainPopup;
    public AudioSource mainSource, Jumpscare;


    private IEnumerator ResetEverything()
    {
        yield return new WaitForSeconds(0.5f);

        player.transform.position = Spawn.transform.position;
        player.rotation = new Quaternion(player.rotation.x, player.rotation.y, player.rotation.z, 90f) ;
        Physics.SyncTransforms();

        yield return new WaitForSeconds(2);
        mainSource.Play();
        mainSource.volume = 1f;

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Jumpscare.Play();
            StartCoroutine(ResetEverything());
            Destroy(Trigger.GetComponent<BoxCollider>());
        }
    }
}
