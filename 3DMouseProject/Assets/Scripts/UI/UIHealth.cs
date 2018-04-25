using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {

    [SerializeField] Image[] hearts;

	// Updates hearts by modifying its image depneding on the number of lives 
	void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }

        }
    }
}
