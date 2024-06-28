using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    [SerializeField]
    private AudioClip BGM, build, attacked, getShield, walk, beeAttack;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    public void AttackedAudio()
    {
        audioSource.clip = attacked;
        audioSource.Play();
    }
    
    public void GetShieldAudio()
    {
        audioSource.clip = getShield;
        audioSource.Play();
    }

    public void BuildAudio()
    {
        audioSource.clip = build;
        audioSource.Play();
    }
    
    public void WalkAudio()
    {
        audioSource.clip = walk;
        audioSource.Play();
    }
    public void BeeAttackAudio()
    {
        audioSource.clip = beeAttack;
        audioSource.Play();
    }
}
