using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI uI;

    public Text health, shields,scourse;
    
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
