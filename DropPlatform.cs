using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject platform;
  

    private IEnumerator dropPlayer()
    {
        Vector3 tempPosition ;
        tempPosition = platform.transform.position;
        BoxCollider tempCollider = platform.GetComponent<BoxCollider>();

        yield return new WaitForSeconds(2);
        Debug.Log("Timer done");

        MeshCollider mc = platform.AddComponent(typeof(MeshCollider)) as MeshCollider;
        mc.convex = true;

        Rigidbody rb = platform.AddComponent(typeof(Rigidbody)) as Rigidbody;
        rb.mass = 9f;
        rb.drag = 1f;
        rb.angularDrag = 0.025f;

        Destroy(platform.GetComponent<BoxCollider>());

        yield return new WaitForSeconds(5);

        Destroy(platform.GetComponent<Rigidbody>());

        BoxCollider newBox = platform.AddComponent(typeof(BoxCollider)) as BoxCollider;
        newBox.isTrigger = true;
        newBox.size =new Vector3(newBox.size.x,newBox.size.y, 0.02f);

        platform.transform.position = tempPosition;

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            StartCoroutine(dropPlayer());
        }
    }
}
