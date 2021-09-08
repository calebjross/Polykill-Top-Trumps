using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSounds : MonoBehaviour
{

    /// <summary>
    /// Script NOT WORKING. I don't know why.
    /// </summary>


    CardBehavior cardBehavior;
    [SerializeField]
    AudioClip[] audioClips = new AudioClip[9];
    int currentClip;
    AudioClip nextClip;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        cardBehavior = GetComponent<CardBehavior>();
        currentClip = 0;
        nextClip = audioClips[currentClip];
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        audioSource.PlayOneShot(nextClip, 0.2f);
        if (currentClip >= audioClips.Length - 1)
        {
            currentClip = 0;
        }
        else currentClip++;
        nextClip = audioClips[currentClip];
    }
}
