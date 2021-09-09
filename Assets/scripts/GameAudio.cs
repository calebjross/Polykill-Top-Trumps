using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips = new AudioClip[9];

    AudioSource audioSource;

    //special conditions
    public bool isOnFire = false; // winning streak
    public bool isFlipSound = false;  // fard flip
    public bool isBattling = false; // cards battling
    public bool isPlayerWin = false; // indicates that the player has won a hand
    public bool isComputerWin = false; // indicates that the computer has won a hand
    /// </summary>

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

        if(isBattling == true)
        {
            audioSource.PlayOneShot(audioClips[2], 1f);
                isBattling = false;
        }

        if (isPlayerWin == true)
        {
            audioSource.PlayOneShot(audioClips[3], 1f);
            isPlayerWin = false;
        }

        if (isComputerWin == true)
        {
            audioSource.PlayOneShot(audioClips[4], 1f);
            isComputerWin = false;
        }
    }
}
