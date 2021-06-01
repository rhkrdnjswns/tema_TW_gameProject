using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] sounds;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            int rand = Random.Range(0, 2);
            audioSource.clip = sounds[rand];
            audioSource.Play();
        }
    }
}
