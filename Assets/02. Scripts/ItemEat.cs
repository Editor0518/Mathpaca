using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemEat : MonoBehaviour
{
    public TMP_Text item;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {

            other.GetComponent<AudioSource>().PlayOneShot(clip);
            
            item.text = (int.Parse(item.text) + 1).ToString();

            gameObject.SetActive(false);
        }
    }
}
