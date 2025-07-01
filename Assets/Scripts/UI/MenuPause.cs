using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject menuPause;
    public bool pauseGame = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseGame)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1.0f;
        pauseGame = false;
    }

    public void pause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        pauseGame = true;
    }
}
