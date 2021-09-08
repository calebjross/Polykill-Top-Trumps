using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips = new AudioClip[9];

    AudioSource audioSource;

    //special conditions
    public bool isOnFire = false;
    public bool isFlipSound = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnFire == true)
        {
            audioSource.PlayOneShot(audioClips[0],1f);
            isOnFire = false;
        }

        if (isFlipSound == true)
        {
            audioSource.PlayOneShot(audioClips[1], 1f);
            isFlipSound = false;
        }
    }
}
