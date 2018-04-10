using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player script. Manages the health and interaction with enemies of the player.
/// </summary>
// [RequireComponent (typeof(PlatformerController))]
public class Player : MonoBehaviour {


	public static Player instance;

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
	public void Die ()
	{
		Invoke ("Remove" , 1);
		// Restart game here
	}

	/// <summary>
	/// Remove the player.
	/// </summary>
	public void Remove (){
		Destroy (gameObject);
	}

}
