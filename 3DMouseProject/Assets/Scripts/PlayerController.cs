using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script for general purpose 3D controls for any object that can move when grounded.
/// </summary>
[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[Header ("Controls")]
	[HideInInspector] public float moveLR; // move left and right
	[HideInInspector] public float moveFB; // move back and forth
	[HideInInspector] public bool inputFire;    // Shoot (whether Mouse is pressed or not)


	[Header ("Jumping")]
	public float jumpForce = 5f;
	private Collider coll;


	[Header ("Shooting")]
	[Tooltip("How fast is the player shooting")]
	public float rateOfFire = 2;
	private float lastTimeFired = 0;


	[Header ("Others")]
	public float speed = 2f;
	private Rigidbody rb;
	// private float gravity = 5f;
	// public Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		coll = GetComponent<Collider> ();
		 
	}

	// Q: Chracter Controller or Rigidbody?

	void FixedUpdate () {
		moveLR = Input.GetAxisRaw ("Horizontal");
		moveFB = Input.GetAxisRaw ("Vertical");
		rb.velocity = new Vector3 (moveLR * speed, rb.velocity.y, moveFB * speed);


	}

	// Update is called once per frame
	void Update () {
		
		// Get the Screen positions of the player
		// Vector3 playerOnScreen = Camera.main.WorldToViewportPoint (transform.position);

		// Get the Screen position of the mouse
		/*
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.y = 0;
		// Get the angle between the points
		float angle = AngleBetweenTwoPoints(transform.position, mousePos);

		// Rotate the player where the mouse is pointing at

		transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
		//transform.rotation = Quaternion.AngleAxis (angle, Vector3.up);

		*/

		if (Input.GetButtonDown ("Jump") && Grounded()) {
			// rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
			rb.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -0.5f * Physics.gravity.y), ForceMode.VelocityChange);

		}
		if (inputFire && (lastTimeFired + 1 / rateOfFire) < Time.time)
		{
			lastTimeFired = Time.time;
			// Fire();
		}
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
		return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg - 90;
	}

	// Look below the character and see if there is a collider
	bool Grounded () {
		return Physics.Raycast (transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);
	}




}
