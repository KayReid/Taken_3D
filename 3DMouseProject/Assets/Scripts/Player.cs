using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player script. Manages the health and interaction with enemies of the player.
/// </summary>
// [RequireComponent (typeof(PlatformerController))]
public class Player : MonoBehaviour {


	public static Player instance;
	public int hitpoints = 10;
	float lastHitTime = 0;

	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Destroy the player
	/// </summary>
	public void Injure (){
		if (Time.time >= lastHitTime + 3) {
			hitpoints--; 
			print (hitpoints);
			// Need some kind of blinking animation and sound here
			if (hitpoints == 0) {
				Die ();
			}
			lastHitTime = Time.time;
		}
	}

	/// <summary>
	/// Destroy the player
	/// </summary>
	public void Die ()
	{
		Invoke ("Remove" , 1);
		// Need some kind of death animation and sound here
		// Restart game here
	}

	/// <summary>
	/// Remove the player.
	/// </summary>
	public void Remove (){
		Destroy (gameObject);
	}

}
