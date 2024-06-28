using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting2 : MonoBehaviour
{
    public float speed = 3f;

    Transform playerPos;
    Rigidbody2D rigidbody2D;
    public float lifeTime = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform;
        Vector3 direction = (playerPos.position - transform.position).normalized;
        rigidbody2D.AddForce(new Vector2(direction.x, direction.y) * speed);
        // transform.Rotate(new Vector3(0, 0, direction.z), Space.Self);
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
