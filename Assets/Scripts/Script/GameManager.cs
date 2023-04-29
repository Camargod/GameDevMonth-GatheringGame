using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;

    public int score;
    public int Life = 3;
    public float timer;
    [SerializeField] private string GameOver;
    [SerializeField] private GameObject heartHUD;
    [SerializeField] private GameObject heart1HUD;
    [SerializeField] private GameObject heart2HUD;
    [SerializeField] private GameObject heart3HUD;

    private int totalScore;
    private int totalLife;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        totalScore = PlayerPrefs.GetInt("score");
        totalLife = PlayerPrefs.GetInt("HP");
        //timer = PlayerPrefs.GetFloat("timer");
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        int timerInt = ((int)timer);
        timerText.text = timerInt.ToString();

        if(timerInt <= 0)
        {
            SceneManager.LoadScene(GameOver);
        }
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        totalScore++;

        PlayerPrefs.SetInt("score", totalScore);
    }
    public void LessLife()
    {
        Life--;
        LifeHUD();
    }
    public void LifeHUD()
    {   
        if(Life == 3){
            heart1HUD.SetActive(false);
            heart2HUD.SetActive(false);
            heart3HUD.SetActive(true);
        }
        if(Life == 2)
        {
            heart1HUD.SetActive(false);
            heart3HUD.SetActive(false);
            heart2HUD.SetActive(true);
        }
        if(Life == 1)
        {
            heart2HUD.SetActive(false);
            heart3HUD.SetActive(false);
            heart1HUD.SetActive(true);
        }
        if(Life == 0)
        {
            heart2HUD.SetActive(false);
            heart3HUD.SetActive(false);
            heart1HUD.SetActive(false);
            SceneManager.LoadScene(GameOver);
        }
    }

}
