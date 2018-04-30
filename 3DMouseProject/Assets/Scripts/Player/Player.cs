using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player script. Manages the health and interaction with enemies of the player.
/// </summary>
[RequireComponent (typeof(PlayerController))]
public class Player : MonoBehaviour {

    public static Player instance;

    public Material[] damageMaterials;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public bool invulnerable = false;

    public int maxHealth = 5;
	private int hitPoints = 5;
    private float hurtTime = 2f;

    // Use this for initialization
    void Awake () {
		Time.timeScale = 1f;
		instance = this;
		Key.keyActivated = false;
		Cannon.cannonCounter = 0;
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
            HurtImage.instance.DisplayHurt(hurtTime);
            Die();
            return;
        }

        AudioSource.PlayClipAtPoint(hurtSound, transform.position); // play sound clip
        CameraController.instance.ScreenShakeLight();
        if (invulnerable == true) {
            HurtImage.instance.DisplayHurt(hurtTime);
            StartCoroutine(Invulnerable(hurtTime));
        }
	}

    IEnumerator Invulnerable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        invulnerable = false;
    }

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
        AudioSource.PlayClipAtPoint(deathSound, transform.position); // play sound clip
        CameraController.instance.ScreenShakeStrong();
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
