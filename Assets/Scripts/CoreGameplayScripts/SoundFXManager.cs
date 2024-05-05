using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    PlayerInputManager playerInputManager;
    private AudioSource audioSource;
    [SerializeField] AudioClip walkSound;
    [SerializeField] AudioClip swordThrust;
    //[SerializeField] GameObject leftFootStep;
    //[SerializeField] GameObject rightFootStep;
    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>() ;
        audioSource = GetComponent<AudioSource>();
        //walkSound = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void SwordThrustAudio()
    {
        audioSource.pitch = 1;
        audioSource.volume = .1f;
        audioSource.PlayOneShot(swordThrust);
    }

    private void StepAudio()
    {
        audioSource.pitch = 1f;
        audioSource.volume = 1f;
        audioSource.PlayOneShot(walkSound);
    }
}
