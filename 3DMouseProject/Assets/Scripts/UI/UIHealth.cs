using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {

    [SerializeField] Image[] hearts;
    public static UIHealth instance;

    void Awake()
    {
        instance = this;
    }

    // Updates hearts by modifying its image depending on the number of lives 
    public void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++){
            if (i < lives){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
