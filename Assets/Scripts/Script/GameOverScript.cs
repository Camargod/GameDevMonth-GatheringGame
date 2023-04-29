using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private string LvlName;
    [SerializeField] private string MenuPrincipal;

    public void RestartGame(){

        SceneManager.LoadScene(LvlName);
    }
    public void BackMenu(){

        SceneManager.LoadScene(MenuPrincipal);

    }   
    
}
