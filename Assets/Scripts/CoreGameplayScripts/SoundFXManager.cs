using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
using UnityEngine.Rendering;
using System.Xml.Serialization;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;

    PlayerInputManager playerInputManager;
   
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    public void EnableAndDisableSoundFX(AudioSource audioSource, Transform audioTarget, float audioDistance)
    {
        if (Vector3.Distance(audioSource.transform.position, audioTarget.position) < audioDistance)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }

    public void CollisionSoundFX(AudioSource source, AudioClip collisionSound, float volume)
    {
        if (Time.timeScale == 1)
        {
            source.PlayOneShot(collisionSound, volume);
        }
    }

    public void ActionSoundFX(AudioSource actionAudioSource, AudioClip actionSound, float volume)
    {
        if (Time.timeScale == 1)
        {
            actionAudioSource.volume = volume;
            actionAudioSource.PlayOneShot(actionSound, volume);
        }
    }

    public void InteractionSoundFX(AudioSource interactionAudioSource, AudioClip interactionAudioClip, float volume)
    {
        if (Time.timeScale == 1)
        {
            interactionAudioSource.PlayOneShot(interactionAudioClip, volume);
        }
    }
    /*void SwordThrustAudio()
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
    }*/
}
