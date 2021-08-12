using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePrevencaoCamera : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    void FixedUpdate()
    {
        Vector3 startPosition = new Vector3(target.position.x, 0f, -1f);

    }
}
