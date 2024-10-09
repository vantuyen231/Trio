using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    private AudioSource scource;

    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        scource = GetComponent<AudioSource>();
        int randomNumber = Random.Range(0, clips.Length);
        scource.clip = clips[randomNumber];
        scource.Play();
    }


}
