using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {

	/*
	[Header ("Shooting")]
	public float rateOfFire = 2; // How fast is the player shooting
	public GameObject shitPrefab; // Prefab to be instantiated when pooping
	private float lastTimeFired = 0;
	*/
	[Tooltip("How fast is the poop moving towards the mouse pointer")]
	public float speed = 13;
	[Tooltip("After how many seconds is the shit destroyed")]
	public float lifeTime = 0.5f;
	[Tooltip("The direction the shit travels")]
	public Vector3 direction;
	[Tooltip("Sound played when shitting.")]
	public AudioClip shootSound;
	[Tooltip("How far the shooting can go")]
	public float range = 50f; 



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (inputFire && (lastTimeFired + 1 / rateOfFire) < Time.time)
		{
			lastTimeFired = Time.time;
			// Fire();
		}
		*/
		if (Input.GetMouseButtonDown(0)) {
			Shoot ();
		}

	}

	// USE THE PARTICLE SYSTEM for extra effects (can be imported by particle system in Unity)


	void Shoot() {
		print ("shoot");
		RaycastHit hit;
		if (Physics.Raycast (Player.instance.transform.position, PlayerController.instance.facing, out hit, range)) {
			print ("hit");
			Debug.Log (hit.transform.name);

			// Target target = hit.transform.GetComponent<Target> ();
			//if (target != null) { // Only do this when found the component. 
			//	target.damage();
			//}

		}

	}

}
