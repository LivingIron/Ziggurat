using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEmission : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem CandleSmall;
    public ParticleSystem CandleMedium;
    public ParticleSystem CandleLarge;
    void Start()
    {
        CandleSmall.enableEmission = false;
        CandleMedium.enableEmission = false;
        CandleLarge.enableEmission = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CandleSmall.enableEmission = true;
            CandleMedium.enableEmission = true;
            CandleLarge.enableEmission = true;
        }
    }
}
