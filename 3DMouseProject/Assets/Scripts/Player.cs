using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player script. Manages the health and interaction with enemies of the player.
/// </summary>
[RequireComponent (typeof(PlayerController))]
public class Player : MonoBehaviour {

    public static Player instance;
    public int maxHealth = 5;
	private int hitPoints = 5;

    // All code regarding the injury coroutine has been borrowed and modified for reuse
    // <copyright file="Player.cs" company="DIS Copenhagen">
    // Copyright (c) 2017 All Rights Reserved
    // </copyright>
    // <author>Benno Lueders</author>
    // <date>07/14/2017</date>
    float hurtTimer = 0.1f;
    Coroutine hurtRoutine;

    // Use this for initialization
    void Awake () {
		instance = this;
        UIHealth.instance.UpdateLives(hitPoints);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Take away one hitpoint from the player. If the player's health is at 0, then the player will be removed.
    /// The player will be invulnerable for hurtTimer time.
	/// </summary>
	public void Injure (){
		
		hitPoints--;
        UIHealth.instance.UpdateLives(hitPoints);

        if (hitPoints == 0){
            Die();
            return;
        }   

        if (hurtRoutine != null){
            StopCoroutine(hurtRoutine);
        }
        hurtRoutine = StartCoroutine(HurtRoutine());
        CameraController.instance.ScreenShakeLight();
		
	}

    // borrowed code
    IEnumerator HurtRoutine()
    {
        float timer = 0;
        bool blink = false;
        while (timer < hurtTimer)
        {
            blink = !blink;
            timer += Time.deltaTime;
            if (blink)
            {
                Player.instance.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                Player.instance.gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
            yield return new WaitForSeconds(0.05f);
        }

        Player.instance.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
    // /borrowed code

    /// <summary>
    /// Should only be called by the Cheese script, where if the player's health is below 5, then one heart will be given back.
    /// If health is already at maxHealth, do nothing.
    /// </summary>
    public void Heal()
    {
        if (hitPoints < maxHealth)
        {
            hitPoints++;
            UIHealth.instance.UpdateLives(hitPoints);
        }
    }

	/// <summary>
	/// Destroy the player
	/// </summary>
	public void Die ()
	{
        CameraController.instance.ScreenShakeStrong();
		Invoke ("Remove" , 1);
        GameManager.instance.RestartTheGameAfterSeconds(1);
		// Need some kind of death animation and sound here]
	}

	/// <summary>
	/// Remove the player.
	/// </summary>
	public void Remove (){
		Destroy (gameObject);
	}

}
