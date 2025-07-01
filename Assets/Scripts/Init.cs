using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public void InitScene()
    {
        SceneManager.LoadScene("Game");
    }
}
