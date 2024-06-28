using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playgame : MonoBehaviour
{
    public GameObject start;
    public GameObject pause;
    public GameObject re;

    public void startGame()
    {
        start.SetActive(false);
        Time.timeScale = 1f;
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pause.SetActive(true);
    }
    public void resumeGame()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
    }
    public void rePlay()
    {
        GameController.instance.health = 10;
        Time.timeScale = 1f;
        re.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
