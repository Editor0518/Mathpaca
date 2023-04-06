using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSomething : MonoBehaviour
{

    public GameObject obj;
    public GameObject obj2;

    public AudioClip clip;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            obj.SetActive(true);
            obj2.SetActive(true);
            if(clip!=null) other.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        } 
    }
    bool didonce = false;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            if (didonce) return;
            if (obj != null) obj.SetActive(false);
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
            didonce = true;

        }
    }

}
