using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Trigger;
    public AudioSource mainSource, Whisper1, Whisper2, Whisper3;


    public static class FadeAudioSource
    {

        public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = audioSource.volume;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }



    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            StartCoroutine(FadeAudioSource.StartFade(mainSource, 2f, 0.2f));
            StartCoroutine(FadeAudioSource.StartFade(Whisper1, 2f, 0f));
            StartCoroutine(FadeAudioSource.StartFade(Whisper2, 2f, 0f));
            StartCoroutine(FadeAudioSource.StartFade(Whisper3, 2f, 0f));
            Destroy(Trigger.GetComponent<BoxCollider>()); 
        }
    }
}
