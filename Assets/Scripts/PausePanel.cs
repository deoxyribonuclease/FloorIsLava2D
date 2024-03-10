using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject Pausep;
    public void Pause()
    {
        Pausep.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Pausep.SetActive(false);
        Time.timeScale = 1;
    }
}
