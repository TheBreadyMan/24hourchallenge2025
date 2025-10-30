using NUnit.Framework;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class RandomSound : MonoBehaviour
{

    public AudioSource FollowPlayerSound;


    public AudioClip[] sounds;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        StartCoroutine(PlaySound());


    }

  
    public IEnumerator PlaySound()
    {

        yield return new WaitForSeconds(Random.Range(7, 10));

        int r = Random.Range(0, sounds.Length);
        AudioClip clip = sounds[r];
        FollowPlayerSound.clip = clip;
        FollowPlayerSound.Play();

    }



  
}
