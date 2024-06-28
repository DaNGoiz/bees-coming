using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI uI;
    /*public List<GameObject> health;
    public List<GameObject> shields;*/

    public Text health, shields,scourse;
    
    void Start()
    {
        
    }
    void Update()
    {
        Health();
    }

    void Health()
    {
        health.text = GameController.instance.health.ToString();
        shields.text = GameController.instance.shields.ToString();
        scourse.text = "Scores: " + GameController.instance.scores.ToString();
    }

    public void A()
    {
        SceneManager.LoadScene(0);
    }
}
