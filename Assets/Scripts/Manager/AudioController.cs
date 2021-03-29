using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    #pragma warning disable 0649

    [Header("References")]

    [SerializeField] private AudioSource _audioSource;

    [Header("SFXs")]
    
    [SerializeField] private AudioClip scoresoundSFX1;
    [SerializeField] private AudioClip scoresoundSFX2;
    [SerializeField] private AudioClip finalSFX;

    #pragma warning restore 0649


    public static AudioController audioController;

    private void Awake()
    {
        audioController = this;

    }

    public void PlayGetPointSFX()
    {
        int randomSound = Random.Range(0, 2);

        if (randomSound == 0)
        {
            _audioSource.PlayOneShot(scoresoundSFX1);
        }
        else
        {
            _audioSource.PlayOneShot(scoresoundSFX2);
        }

    }




    public void PlayFinishSFX()
    {
        _audioSource.PlayOneShot(finalSFX);
    }


}