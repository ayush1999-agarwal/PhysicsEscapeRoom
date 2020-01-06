



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] float delta = 1.5f;
    [SerializeField] float speed = 2.0f;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        if (transform.rotation.y == 0)
        {
            v.z += delta * Mathf.Sin(Time.time * speed);
        }
        else
        {
            v.x += delta * Mathf.Sin(Time.time * speed);
        }
        transform.position = v;
    }
}
