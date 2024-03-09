using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float topPositionY = 5f;    
    public float bottomPositionY = 0f;  
    public float speed = 2f;            

    private bool movingUp = true;       

    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                                      new Vector2(transform.position.x, topPositionY),
                                                      speed * Time.deltaTime);

            if (transform.position.y >= topPositionY)
            {
                movingUp = false;   
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                                      new Vector2(transform.position.x, bottomPositionY),
                                                      speed * Time.deltaTime);
            if (transform.position.y <= bottomPositionY)
            {
                movingUp = true;    
            }
        }
    }
}
