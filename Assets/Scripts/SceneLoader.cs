using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject mathsQ = null;

    private void Awake()
    {
        if (gameObject.tag == "Desktop")
        {
            if (PlayerPrefs.GetString("CircuitComplete") == "True")
            {
                mathsQ.SetActive(true);
            }
        }
        if(gameObject.tag == "Door" && PlayerPrefs.GetString("padInput") == "49")
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 10, 0));
        }
    }
    public void OnMouseDown()
    {
        if (gameObject.tag == "Desktop")
        {
            
            if(PlayerPrefs.GetString("CircuitComplete") != "True")
            {
                SceneManager.LoadScene("ShortCircuit");
            }
            else
            {
                SceneManager.LoadScene("MathsProblem");
            }
        }
        if(gameObject.tag == "Door" && PlayerPrefs.GetString("padInput") == "49")
        {
            SceneManager.LoadScene("Gravity");
        }
        if(gameObject.tag == "NumPad")
        {
            SceneManager.LoadScene("NumPad");
        }
    }
    public void ShortCIrcuitComplete()
    {
        SceneManager.LoadScene("Lab");
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnResetClick()
    {
        PlayerPrefs.DeleteAll();
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
