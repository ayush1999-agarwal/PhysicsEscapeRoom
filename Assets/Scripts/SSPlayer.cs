using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSPlayer : MonoBehaviour
{
    [SerializeField] int moveSpeed = 5;
    public int score = 3;
    [SerializeField] AudioClip targetReached;
    [SerializeField] AudioClip explosion;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] Text circuitCompText;
    [SerializeField] Text shortCircuitText;
    bool canWin = true;
    public Vector3 Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
            StopCoroutine("MovePlayer");
            StartCoroutine("MovePlayer", target);

        }
    }
    private Vector3 target = new Vector3(0, 0, 0);
    IEnumerator MovePlayer(Vector3 target)
    {
        while (gameObject.transform.position != target)
        {
            transform.position = Vector3.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private void Awake()
    {
        PlayerPrefs.SetString("CircuitComplete", "False");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Wire")
        {
            shortCircuitText.gameObject.SetActive(true);
            AudioSource.PlayClipAtPoint(explosion, transform.position);
            var expVFX = Instantiate(explosionVFX, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            expVFX.transform.parent = transform;
            StartCoroutine(WaitToDisplayExplosion());
            canWin = false;
        }
        else if (other.gameObject.tag == "Target")
        {
            if (canWin)
            {
                Destroy(other.gameObject);
                AudioSource.PlayClipAtPoint(targetReached, transform.position);
                score--;
                if (score == 0)
                {
                    PlayerPrefs.SetString("CircuitComplete", "True");
                    circuitCompText.gameObject.SetActive(true);
                    StartCoroutine(WaitToDisplayResult());
                }
            }
        }
    }
    IEnumerator WaitToDisplayResult()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<SceneLoader>().ShortCIrcuitComplete();
    }
    IEnumerator WaitToDisplayExplosion()
    {
        PlayerPrefs.SetString("CircuitComplete", "False");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        FindObjectOfType<SceneLoader>().ShortCIrcuitComplete();
    }

}
