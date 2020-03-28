﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager current;
    [Header("环境声")]
    public AudioClip ambientClip;
    public AudioClip musicClip;

    [Header("FX音效")]
    public AudioClip deathFXClip;
    public AudioClip orbFXClip;
    public AudioClip doorFXClip;
    public AudioClip startLevelClip;
    public AudioClip winClip;

    [Header("Robbie音效")]
    public AudioClip[] walkStepClips;
    public AudioClip[] crouchStepClip;
    public AudioClip jumpClip;
    public AudioClip deathClip;

    public AudioClip jumpVoiceClip;
    public AudioClip deathVoiceClip;
    public AudioClip orbVoiceClip;


    AudioSource ambientSource;
    AudioSource musicSource;
    AudioSource fxSource;
    AudioSource playerSource;
    AudioSource voiceSource;

    public AudioMixerGroup ambientGroup, musicGroup, FXGroup, playerGroup, voiceGroup;

    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
            return;
        }
        current = this;        
        DontDestroyOnLoad(gameObject);//场景切换不销毁
        ambientSource = gameObject.AddComponent<AudioSource>();
        musicSource= gameObject.AddComponent<AudioSource>();
        fxSource= gameObject.AddComponent<AudioSource>();
        playerSource= gameObject.AddComponent<AudioSource>();
        voiceSource= gameObject.AddComponent<AudioSource>();

        ambientSource.outputAudioMixerGroup=ambientGroup;
        musicSource.outputAudioMixerGroup = musicGroup;
        fxSource.outputAudioMixerGroup = FXGroup;
        playerSource.outputAudioMixerGroup = playerGroup;
        voiceSource.outputAudioMixerGroup = voiceGroup;

        StartLevelAudio();
    }

    void StartLevelAudio()
    {
        current.ambientSource.clip = current.ambientClip;
        current.ambientSource.loop = true;
        current.ambientSource.Play();

        current.musicSource.clip = current.musicClip;
        current.musicSource.loop = true;
        current.musicSource.Play();
    }

    public static void PlayFootstepAudio()
    {
        int index = Random.Range(0,current.walkStepClips.Length);

        current.playerSource.clip = current.walkStepClips[index];
        current.playerSource.Play();
    }
    public static void PlayCrouchstepAudio()
    {
        int index = Random.Range(0, current.crouchStepClip.Length);

        current.playerSource.clip = current.crouchStepClip[index];
        current.playerSource.Play();
    }

    public static void PlayJumpAudio()
    {
        current.playerSource.clip = current.jumpClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.jumpVoiceClip;
        current.voiceSource.Play();
    }
    public static void PlayDeathAudio()
    {
        current.playerSource.clip = current.deathClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.deathVoiceClip;
        current.voiceSource.Play();

        current.fxSource.clip = current.deathFXClip;
        current.fxSource.Play();                                                                               
    }

    public static void PlayOrbAudio()
    {
        current.voiceSource.clip = current.orbVoiceClip;
        current.voiceSource.Play();

        current.fxSource.clip = current.orbFXClip;
        current.fxSource.Play();
    }
    public static void PlayDoorAudio()
    {
        current.fxSource.clip = current.doorFXClip;
        current.fxSource.PlayDelayed(1f);
    }
    public static void PlayStartLevelAudio()
    {
        current.fxSource.clip = current.startLevelClip;
        current.fxSource.Play();
    }
    public static void PlayWinAudio()
    {
        current.fxSource.clip = current.winClip;
        current.fxSource.Play();
        current.playerSource.Stop();
    }
}
