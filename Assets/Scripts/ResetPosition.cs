using UnityEngine;
using UnityEngine.Events;

public class ResetPosition : MonoBehaviour
{
    public Transform objectToReset;

    private Vector3 originalPosition;
    private Vector3 originalVelocity;

    public UnityEvent onReset;

    void Start()
    {
        originalPosition = objectToReset.position;
        Rigidbody2D rb = objectToReset.GetComponent<Rigidbody2D>();
        if (rb != null)
            originalVelocity = rb.velocity;
    }

    public void ResetObject()
    {
        objectToReset.position = originalPosition;
        Rigidbody2D rb = objectToReset.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = originalVelocity;

        onReset.Invoke();
    }
}
