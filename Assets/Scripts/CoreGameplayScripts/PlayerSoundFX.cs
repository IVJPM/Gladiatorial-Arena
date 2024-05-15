using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundFX : MonoBehaviour
{

    PlayerInputManager playerInputManager;
    private AudioSource audioSource;
    [SerializeField] AudioClip runSound;
    [SerializeField] AudioClip swordThrust;
    //[SerializeField] GameObject leftFootStep;
    //[SerializeField] GameObject rightFootStep;
    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        audioSource = GetComponent<AudioSource>();
        //walkSound = audioSource.clip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StepAudio()
    {
        audioSource.pitch = 1f;
        audioSource.volume = .25f;
        audioSource.PlayOneShot(runSound);
    }
}
