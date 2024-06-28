using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject start;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        // start.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
