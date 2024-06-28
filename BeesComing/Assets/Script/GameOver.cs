using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    void Start()
    {
        
    }

    void Update()
    {
        Game();
    }

    public void Game()
    {
        if(GameController.instance.health==0)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
}
