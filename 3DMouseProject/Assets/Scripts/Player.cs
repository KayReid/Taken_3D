using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player script. Manages the health and interaction with enemies of the player.
/// </summary>
[RequireComponent (typeof(PlayerController))]
public class Player : MonoBehaviour {

    public static Player instance;
    public Renderer playerRenderer;
    public Material[] damageMaterials;
    public bool invulnerable = false;

    public int maxHealth = 5;
	private int hitPoints = 5;

    // All code regarding the injury coroutine has been borrowed and modified for reuse
    // <copyright file="Player.cs" company="DIS Copenhagen">
    // Copyright (c) 2017 All Rights Reserved
    // </copyright>
    // <author>Benno Lueders</author>
    // <date>07/14/2017</date>


    // Use this for initialization
    void Awake () {
		instance = this;
        UIHealth.instance.UpdateLives(hitPoints);
        playerRenderer = GetComponent<Renderer>();
        playerRenderer.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Take away one hitpoint from the player. If the player's health is at 0, then the player will be removed.
    /// The player will be invulnerable for hurtTimer time.
	/// </summary>
	public void Injure (){
        invulnerable = true;
		hitPoints--;
        UIHealth.instance.UpdateLives(hitPoints);
        if (hitPoints == 0){
            Die();
            return;
        } 
        //Debug.Log("Taking Damage");
        CameraController.instance.ScreenShakeLight();
        if (invulnerable == true) {
            StartCoroutine(Invulnerable(3));
        }
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


    IEnumerator Invulnerable (float seconds)
    {
        Debug.Log("Invulnerable for 2 seconds");
        yield return new WaitForSeconds (seconds);
        invulnerable = false;
    }

}
