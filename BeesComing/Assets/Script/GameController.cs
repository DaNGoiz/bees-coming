using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject lifePrefab;
    public AudioClip getShield, attacked;
    public int health = 3;
    public int shields = 0;

    AudioSource audioSource;
    public int scores = 0;
    // GameObject[] lives;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }


    public void addHealth()
    {
        health++;
        scores += 5;
    }
    public void lossHealth()
    {
        if(shields > 0)
            shields--;
        else
            health--;
        audioSource.clip = attacked;
        audioSource.Play();
    }
    public void addShield()
    {
        shields++;
        scores += 5;
        audioSource.clip = getShield;
        audioSource.Play();
    }

    public void addScores()//放置方块加分
    {
        scores += 10;
    }
}
