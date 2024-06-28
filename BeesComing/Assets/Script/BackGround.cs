using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform cameraa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraa.position.x, cameraa.position.y, 0);
        transform.rotation = cameraa.rotation;
    }
}
