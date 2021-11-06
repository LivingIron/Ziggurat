using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAP1 : MonoBehaviour
{
    [SerializeField] private GameObject Assets, finalDestroy;
    [SerializeField] private GameObject Platforms1,Candlebras;
    [SerializeField] private BoxCollider InvisibleWall1, InvisibleWall2, InvisibleWall3;
    void Start()
    {      
        InvisibleWall1.GetComponent<BoxCollider>();
        InvisibleWall2.GetComponent<BoxCollider>();
        InvisibleWall3.GetComponent<BoxCollider>();
    }


    private IEnumerator turnOnPhysics(){
        
        yield return new WaitForSeconds(2);
        Debug.Log("Timer done");
        Rigidbody rb = Platforms1.AddComponent(typeof(Rigidbody)) as Rigidbody;
        Rigidbody rb2 = Candlebras.AddComponent(typeof(Rigidbody)) as Rigidbody;
        MeshCollider mc = Platforms1.AddComponent(typeof(MeshCollider)) as MeshCollider;

        mc.convex = true;
        rb.mass = 0.5f;
        rb.drag = 3f;
        rb.angularDrag = 0.1f;
        rb2.mass = 1f;
        rb2.drag = 2f;
        rb2.angularDrag = 0.05f;

        yield return new WaitForSeconds(6);
        Destroy(Platforms1);
       
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(Assets);

            BoxCollider tempBox = finalDestroy.GetComponent<BoxCollider>();
            tempBox.isTrigger = false;
            Destroy(tempBox);

            InvisibleWall1.enabled = true;
            InvisibleWall2.enabled = true;
            InvisibleWall3.enabled = true;
            Debug.Log("Collider.enabled=" + InvisibleWall1.enabled);

            StartCoroutine(turnOnPhysics());
            
        }


    }
}
    
