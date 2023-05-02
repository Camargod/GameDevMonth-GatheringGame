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
    [SerializeField] private string NFase;
    [SerializeField] private int scoreLimit;
    [SerializeField] private GameObject PainelTutorial;
    [SerializeField] private GameObject heartHUD;
    [SerializeField] private GameObject heart1HUD;
    [SerializeField] private GameObject heart2HUD;
    [SerializeField] private GameObject heart3HUD;
    [SerializeField] static float totalScore;
    public static bool save;
    private float totalLife;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    //    totalScore = PlayerPrefs.GetInt("score");
        totalLife = PlayerPrefs.GetInt("HP");
        //timer = PlayerPrefs.GetFloat("timer");
        save = false;
        totalScore = PlayerPrefs.GetFloat("totalScore");
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
        saveScore();
        NextFase();
               
    }

    private void saveScore(){
        if(save == true){
            PlayerPrefs.SetFloat("totalScore", totalScore);
            PlayerPrefs.Save();
        }
    }
    
    public void CloseTutorial(){

        PainelTutorial.SetActive(false);
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        score++;

        //PlayerPrefs.SetInt("score", totalScore);
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
     public void NextFase(){
        if(score >= scoreLimit){
        totalScore = totalScore + timer;
        save = true;
        scoreText.text = totalScore.ToString();
        SceneManager.LoadScene(NFase);
          
        }
     }

}
