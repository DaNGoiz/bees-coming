using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public Transform player;

    private void Update() 
    {
        transform.position = player.position;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Bullet"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            GameController.instance.lossHealth();
        }
    }
    
        
}
