using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {


	[Header ("Shooting")]
	public GameObject poopPrefab; // Prefab to be instantiated when pooping
	public float rateOfFire = 2; // How fast is the player shooting
	private float lastTimeFired = 0; // Last time when the player pooped
	public float Shitspeed = 13; // How fast is the poop moving towards the mouse pointer
	public float range = 50f; // How far the shooting can go
	public Transform firePoint;
	public bool canShoot;


	private LineRenderer laserline;



	// Use this for initialization
	void Start () {
		laserline = GetComponent<LineRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (canShoot) {
			
		}
	}
	// Shoot the poop
	void Shoot() {
		



	}


	/*
	Vector3 BallisticVel (Vector3 targetPos) {
		
		Vector3 direction = targetPos - transform.position;
		float h = direction.y;
		direction.y = 0;
		float dist = direction.magnitude;
		float a = angle * Mathf.Deg2Rad; 
		direction.y = dist * Mathf.Tan(a); 
		// set dir to the elevation angle 
		dist += h / Mathf.Tan(a); 
		// correct for small height differences 
		// calculate the velocity magnitude 
		float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a)); 
		return vel * direction.normalized; 


		Vector3 dir = targetPos - transform.position; // get target direction
		float h = dir.y;  // get height difference
		dir.y = 0;  // retain only the horizontal direction
		float dist = dir.magnitude ;  // get horizontal distance
		dir.y = dist;  // set elevation to 45 degrees
		dist += h;  // correct for different heights
		float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude);
		return vel * dir.normalized;  // returns Vector3 velocity
	}
	*/
	IEnumerator ShotEffect(){
		laserline.enabled = true;
		yield return new WaitForSeconds (0.07f);
	}
}
