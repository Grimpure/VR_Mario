using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip Song1, Song2, Song3, Song4;
    public int songNumber;
    //
    // Song1 = Shamen - Mark (Emiel Remix)
    // Song2 = Night lovell - Live television
    // Song3 = Night Lovell - FukkCodeRed
    // Song4 = Night Lovell - BumbleBee
    //
    void Start()
    {
        songNumber = 3;
        audioS.clip = Song3;
        audioS.Play();
        //StartCoroutine(audioPlay());
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    songNumber++;
        //}
        //if(songNumber == 1)
        //{
        //    audioS.clip = Song1;
        //    audioS.Play();
        //}
        //if(songNumber == 2)
        //{
        //    audioS.clip = Song2;
        //    audioS.Play();
        //}
        //if (songNumber == 3)
        //{
        //    audioS.clip = Song3;
        //    audioS.Play();
        //}
        //if (songNumber == 4)
        //{
        //    audioS.clip = Song4;
        //    audioS.Play();
        //}
        //if(songNumber <= 0 || songNumber >= 5)
        //{
        //    songNumber = 1;
        //}
    }
    //IEnumerator audioPlay()
    //{
    //    songNumber = 1;
    //    audioS.clip = Song1;
    //    audioS.Play();
    //    yield return new WaitForSeconds(197.4f);
    //    songNumber = 2;
    //    audioS.clip = Song2;
    //    audioS.Play();
    //    yield return new WaitForSeconds(164);
    //    songNumber = 3;
    //    audioS.clip = Song3;
    //    audioS.Play();
    //    yield return new WaitForSeconds(204.5f);
    //    songNumber = 4;
    //    audioS.clip = Song4;
    //    audioS.Play();
    //    yield return new WaitForSeconds(156.5f);
    //    StartCoroutine(audioPlay());
    //}
}
