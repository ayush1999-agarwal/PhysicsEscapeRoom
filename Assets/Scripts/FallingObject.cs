using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;
    float initDrag;

    public bool vacuumEnabled = false;
    public bool doorEnabled = false;
    [SerializeField] GameObject compartment;

    private void Awake()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
        initDrag = gameObject.GetComponent<Rigidbody>().drag;
    }

    public void StartFall()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void ResetFall()
    {
        gameObject.transform.position = startPos;
        gameObject.transform.rotation = startRot;
        gameObject.GetComponent<Rigidbody>().drag = initDrag;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    public void Vacuum()
    {
        gameObject.GetComponent<Rigidbody>().drag = 0;
        vacuumEnabled = true;
    }

    public void FillAir()
    {
        gameObject.GetComponent<Rigidbody>().drag = initDrag;
        gameObject.GetComponent<Rigidbody>().drag += 0.5f;
    }

    public void LowerHeight()
    {
        gameObject.transform.position -= new Vector3(0, 1, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (vacuumEnabled)
        {
            compartment.SetActive(true);
        }
    }
}
