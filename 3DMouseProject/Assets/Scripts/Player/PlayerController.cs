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
	[HideInInspector] public bool canMove; // Check whether the player can move

	[Header ("Rotation of the player")]
	public Vector3 mousePos;
	public Vector3 target;
	public Camera cam;
	public float mouseSensitivity;

	[Header ("Shooting")]
	public GameObject bulletPrefab; // Prefab to be instantiated when pooping
	public float rateOfFire = 2; // How fast is the player shooting
	private float lastTimeFired = 0; // Last time when the player pooped
	public Transform firePoint;
	public bool canShoot;

	[Header ("Others")]
	public float speed = 2f;
	private Rigidbody rb;

	private Animator mouseAnimation;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		mouseAnimation = GetComponent<Animator> ();
		cam = Camera.main;
		inputFire = false;
		canMove = true; 
		canShoot = true;
	}

	// Movement and Jumping
	void FixedUpdate () {
		// Move left, right, back, and forth
		if (canMove) {
			rb.velocity = new Vector3 (moveLR * speed, rb.velocity.y, moveFB * speed);
			if (moveLR != 0 || moveFB != 0) {
				mouseAnimation.SetBool ("isWalking", true);
			} else {
				mouseAnimation.SetBool ("isWalking", false);
			}
		}

	}

	// Shooting and rotating
	void Update () {
		if (canShoot) {
			if (inputFire && (lastTimeFired + 1 / rateOfFire) < Time.time) {
				lastTimeFired = Time.time;
				Shoot ();
			}
		}
		Rotate ();
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

	// Shoot the bullet
	void Shoot() {
		// Instantiate the bullet
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
		bullet.transform.rotation = transform.rotation;
	}

}


