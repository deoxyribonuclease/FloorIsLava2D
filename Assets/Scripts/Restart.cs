using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public ResetPosition resetPositionScript;
    public string objectTag = "Player";
    public float restartDelay = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(objectTag))
        {
            StartCoroutine(RestartWithDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(objectTag))
        {
            StartCoroutine(RestartWithDelay());
        }
    }

    private IEnumerator RestartWithDelay()
    {
        yield return new WaitForSeconds(restartDelay);
        resetPositionScript.ResetObject();
    }
}
