using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource soundPlayer;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
        playSound(sound, soundPlayer);
    }

    public static void playSound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
