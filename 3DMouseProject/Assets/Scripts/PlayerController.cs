using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script for general purpose 3D controls for any object that can move when grounded.
/// </summary>
[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[Header ("Movement Controls")]
	[HideInInspector] public float moveLR; // move left and right
	[HideInInspector] public float moveFB; // move back and forth
	[HideInInspector] public bool inputFire; // move back and forth
	[HideInInspector] public bool inputJump; // move back and forth

	[Header ("Rotation of the player")]
	public Vector3 mousePos;
	public Vector3 target;
	public Camera cam;
	public float mouseSensitivity;

	[Header ("Jumping")]
	public float jumpForce = 5f;
	public Collider coll;

	[Header ("Shooting")]
	public GameObject poopPrefab; // Prefab to be instantiated when pooping
	public float rateOfFire = 2; // How fast is the player shooting
	private float lastTimeFired = 0; // Last time when the player pooped
	public float Shitspeed = 13; // How fast is the poop moving towards the mouse pointer
	public float range = 50f; // How far the shooting can go
	public Transform firePoint;

	[Header ("Others")]
	public float speed = 2f;
	private Rigidbody rb;

	private Animator mouseAnimation;


	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody> ();
		coll = GetComponent<Collider> ();
		mouseAnimation = GetComponent<Animator> ();
		cam = Camera.main;
		inputFire = false;

	}

	// Movement and Jumping
	void FixedUpdate () {
		// Move left, right, back, and forth

		rb.velocity = new Vector3 (moveLR * speed, rb.velocity.y, moveFB * speed);

		if (inputJump && Grounded()) {
			// rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
			rb.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -0.5f * Physics.gravity.y), ForceMode.VelocityChange);

		}
		if (moveLR != 0 || moveFB != 0) {
			mouseAnimation.SetBool("isWalking", true);
		} else {
			mouseAnimation.SetBool("isWalking", false);
		}

	}

	// Shooting and rotating
	void Update () {
		
		if (inputFire && (lastTimeFired + 1 / rateOfFire) < Time.time)
		{
			// print ("shoot");
			lastTimeFired = Time.time;
			Shoot ();
		}
		/*
		if (inputFire) {
			Shoot ();
		}
		*/
		mouseAnimation.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
		//mouseAnimation.SetFloat("Speed", Mathf.Abs(rb.velocity.y));
		Rotate ();
	}
		
	/// Check whether the player is grounded
	bool Grounded () {
		return Physics.Raycast (transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);
	}

	// Rotate the player to make it face the mouse pointer
	void Rotate () {
		RaycastHit hit;
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 1000)) {
			mousePos = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
		}
		target = mousePos - transform.position;
		Quaternion newRotation = Quaternion.LookRotation (target);

		newRotation.x = 0;
		newRotation.z = 0;

		transform.rotation = Quaternion.Lerp (transform.rotation, newRotation, mouseSensitivity * Time.deltaTime);

	
	}

	// Shoot the poop
	void Shoot() {
		/*
		print ("shoot");
		RaycastHit hit;
		if (Physics.Raycast (Player.instance.transform.position, target, out hit, range)) {
			EnemyFollow enemy = hit.transform.GetComponent<EnemyFollow> ();
			if (enemy != null) { // Only do this when found the component. 
				print ("hit");
				Debug.Log (hit.transform.name);
				enemy.Hurt ();
			}

		}
		*/


		// transform.Rotate(Vector3.up * Time.deltaTime);
		print ("shoot");

		// Instantiate the poop
		GameObject bullet = Instantiate(poopPrefab, firePoint.position, firePoint.rotation) as GameObject;
		bullet.transform.rotation = transform.rotation;


	}

}


