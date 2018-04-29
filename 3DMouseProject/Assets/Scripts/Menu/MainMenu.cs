using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public string firstLevel;
    public GameObject mainMenu;

    public void NewGame() {
        SceneManager.LoadScene(firstLevel);    
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void HowToPlay() {
    	SceneManager.LoadScene("HowToPlay");
    }

    public void backToMenu() {
    	SceneManager.LoadScene("MainMenu");
    }


}
