using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform mainCamera;
    
    void Update()
    {
        transform.position = new Vector3(mainCamera.position.x, mainCamera.position.y, 0);
        transform.rotation = mainCamera.rotation;
    }
}
