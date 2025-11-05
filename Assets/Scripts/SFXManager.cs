using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip playerShoot;
    public AudioClip asteroidExplosion;
    public AudioClip playerDamage;
    public AudioClip playerExplosion;
    public AudioClip BgMusicGameplay;
    public AudioClip BgMusicTitleScreen;
    public AudioClip milestone;

    private int destroyed = 0;

    private AudioSource SFXaudioSource;

    private AudioSource BgMusicAudioSource;
    private float Default;

    public void Awake()
    {
        SFXaudioSource = GetComponent<AudioSource>();
        //GameObject child = this.transform.Find("BgMusic").gameObject;
        BgMusicAudioSource = gameObject.transform.Find("BgMusic").gameObject.GetComponent<AudioSource>();
        
        //default is whatever the pitch is at the start
        Default = SFXaudioSource.pitch;

        
        //BgMusicAudioSource.GetComponent<AudioSource>().Play();       
    }



    //called in the PlayerController Script
    public void PlayerShoot()
    {
        //gets a random range
        int rng = Random.Range(-6, 5);
        //sets pitch to pitch plus that randomrange;
        SFXaudioSource.pitch = SFXaudioSource.pitch + rng;
        //plays the audio
        Debug.Log(SFXaudioSource.pitch);
        SFXaudioSource.PlayOneShot(playerShoot);
        //sets pitch back to default
        SFXaudioSource.pitch = Default;
    }

    //called in the PlayerController Script
    public void PlayerDamage()
    {
        SFXaudioSource.PlayOneShot(playerDamage);
    }

    //called in the PlayerController Script
    public void PlayerExplosion()
    {
        SFXaudioSource.PlayOneShot(playerExplosion);
    }

    //called in the AsteroidDestroy script
    public void AsteroidExplosion()
    {
        SFXaudioSource.PlayOneShot(asteroidExplosion);
        destroyed++;
        if (destroyed >= 10)
        {
            Debug.Log("milestoneplayed");
            SFXaudioSource.PlayOneShot(milestone);
            destroyed = 0;
        }
    }

    
    public void BGMusicMainMenu()
    {
        BgMusicAudioSource.clip = BgMusicTitleScreen;
        BgMusicAudioSource.Play();
    }

    public void BGMusicGameplay()
    {
        BgMusicAudioSource.GetComponent<AudioSource>().clip = BgMusicGameplay;
        BgMusicAudioSource.Play();

    }
}
