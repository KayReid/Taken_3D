using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

	// Use this for initialization
	void Awake () {
        instance = this;
	}

    /// <summary>
    /// Reloads the current scene with some delay in seconds.
    /// </summary>
    /// <param name="seconds">Seconds.</param>
    public void RestartTheGameAfterSeconds(float seconds)
    {
        StartCoroutine(LoadSceneAfterSeconds(seconds));
    }

    // Coroutine to start the game again
    IEnumerator LoadSceneAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainMenu");
    }
}
