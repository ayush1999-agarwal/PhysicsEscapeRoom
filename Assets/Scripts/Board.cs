using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Board : MonoBehaviour
{
    SSPlayer playerPrefab;
    [SerializeField] int timer = 50;
    [SerializeField] Text timerText;
    [SerializeField] Text timeUpText;

    private void Start()
    {
        playerPrefab = FindObjectOfType<SSPlayer>();
        InvokeRepeating("Timer", 0, 1);
    }
    public void Timer()
    {
        timer -= 1;
        timerText.text = timer.ToString();
        if (timer <= 0)
        {
            timeUpText.gameObject.SetActive(true);
            StartCoroutine(WaitToDisplayResult());
        }
    }
    IEnumerator WaitToDisplayResult()
    {
        PlayerPrefs.SetString("CircuitComplete", "False");
        yield return new WaitForSeconds(1f);
        Destroy(FindObjectOfType<SSPlayer>());
        FindObjectOfType<SceneLoader>().ShortCIrcuitComplete();
    }
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if (hit.collider.gameObject == gameObject)
        {
            playerPrefab.Target = hit.point;
        }
    }
}
