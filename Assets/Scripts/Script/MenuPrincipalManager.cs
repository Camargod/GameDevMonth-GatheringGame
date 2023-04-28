using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string LevelName;
    [SerializeField] private GameObject PainelMenu;
    [SerializeField] private GameObject PainelOption;
    [SerializeField] private GameObject PainelCredits;
    [SerializeField] private GameObject PainelRanking;

    public void PlayGame(){

        SceneManager.LoadScene(LevelName);
    }
    public void OpenOption(){

        PainelMenu.SetActive(false);
        PainelOption.SetActive(true);

    }
    public void CloseOption(){

        PainelOption.SetActive(false);
        PainelMenu.SetActive(true);
    }

    public void OpenCredits(){
        
        PainelMenu.SetActive(false);
        PainelCredits.SetActive(true);
    }
    public void CloseCredits(){
        PainelCredits.SetActive(false);
        PainelMenu.SetActive(true);
    }
    public void CloseGame(){
        
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
        
    
}
