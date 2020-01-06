using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContainerButton : MonoBehaviour
{
    FallingObject[] objects;

    [SerializeField] AudioClip vacuum = null;
    [SerializeField] AudioClip airFill = null;
    [SerializeField] GameObject chip = null;
    private void Start()
    {
        objects = FindObjectsOfType<FallingObject>();
    }
    private void OnMouseDown()
    {
        if(gameObject.tag == "Start Fall")
        {
            foreach(var obj in objects)
            {
                obj.StartFall();
            }
        }
        else if(gameObject.tag == "Reset Fall")
        {
            foreach (var obj in objects)
            {
                obj.ResetFall();
            }
        }
        else if(gameObject.tag == "Vaccum Fall")
        {
            AudioSource.PlayClipAtPoint(vacuum, gameObject.transform.position);
            foreach (var obj in objects)
            {
                obj.Vacuum();
            }
        }
        else if(gameObject.tag == "Fill Air Fall")
        {
            AudioSource.PlayClipAtPoint(airFill, gameObject.transform.position);
            foreach (var obj in objects)
            {
                obj.FillAir();
            }
        }
        else if(gameObject.tag == "Lower Fall")
        {
            foreach (var obj in objects)
            {
                obj.LowerHeight();
            }
        }
        else if(gameObject.tag == "Compartment Fall")
        {
            FindObjectOfType<FallingObject>().doorEnabled = true;
            Destroy(chip.gameObject);
        }
        else if(gameObject.tag == "Door")
        {
           if(FindObjectOfType<FallingObject>().doorEnabled)
            {
                SceneManager.LoadScene("Win Screen");
            }
        }
    }
}
