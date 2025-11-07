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
    public AudioClip sheildsdown;

    private int destroyed = 0;
    private int hits = 0;

    private AudioSource SFXaudioSource;

    private AudioSource BgMusicAudioSource;

    private AudioSource nonrandomized;

    public void Awake()
    {
        SFXaudioSource = GetComponent<AudioSource>();
        //GameObject child = this.transform.Find("BgMusic").gameObject;
        BgMusicAudioSource = gameObject.transform.Find("BgMusic").gameObject.GetComponent<AudioSource>();
        nonrandomized = gameObject.transform.Find("norandom").gameObject.GetComponent<AudioSource>();


        //BgMusicAudioSource.GetComponent<AudioSource>().Play();       
    }



    //called in the PlayerController Script
    public void PlayerShoot()
    {
        //gets a random range
        int rng = Random.Range(0, 4);
        //sets pitch to pitch plus that randomrange;
        if (rng == 1)
        {
            SFXaudioSource.pitch = 0.9f;
        }
        if (rng == 2)
        {
            SFXaudioSource.pitch = 1f;
        }
        if (rng == 3)
        {
            SFXaudioSource.pitch = 1.1f;
        }
        
        //plays the audio
        Debug.Log(SFXaudioSource.pitch);
        SFXaudioSource.PlayOneShot(playerShoot);

    }

    //called in the PlayerController Script
    public void PlayerDamage()
    {
        hits = hits + 1;
        Debug.Log(hits);
        if(hits == 6)
        {
            nonrandomized.PlayOneShot(sheildsdown);

        }
        nonrandomized.PlayOneShot(playerDamage);
    }

    //called in the PlayerController Script
    public void PlayerExplosion()
    {
        SFXaudioSource.pitch = 1f;
        destroyed = 0;
        hits = 0;
        SFXaudioSource.PlayOneShot(playerExplosion);
    }

    //called in the AsteroidDestroy script
    public void AsteroidExplosion()
    {
        SFXaudioSource.pitch = 1f;
        SFXaudioSource.PlayOneShot(asteroidExplosion);
        destroyed++;
        if (destroyed >= 10)
        {
            Debug.Log("milestoneplayed");
            nonrandomized.PlayOneShot(milestone);
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
