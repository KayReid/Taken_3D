using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
	// Update is called once per frame
    void Start () {
        pauseMenuUI.SetActive(false);
    }
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
	}

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;    
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // freeze the game
        gamePaused = true;
    }

    public void LoadMenu() {
        //SceneManager.LoadScene("Menu");
        Debug.Log("Loading Menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
