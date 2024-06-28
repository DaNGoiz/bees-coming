using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting1 : MonoBehaviour
{
    public float speed = 5f;
    // public GameObject 

    Rigidbody2D rigidbody2D;
    public float lifeTime = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    public void SetDirection(Vector3 direction)
    {
        rigidbody2D.velocity = new Vector2(direction.x, direction.y) * speed;

        Destroy(gameObject, lifeTime);
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            // other.gameObject.attacked()
            Destroy(gameObject);
        }
    }
}
