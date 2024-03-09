using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public Vector3 rotateChange;

    void Update()
    {
        if(Time.timeScale != 0)
        transform.Rotate (rotateChange); 
    }
}
