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
	public Collider coll;


	[Header ("Shooting")]
	[Tooltip("How fast is the player shooting")]
	public float rateOfFire = 2;
	private float lastTimeFired = 0;


	[Header ("Others")]
	public float speed = 2f;
	private Rigidbody rb;
	public float mouseSensitivity;
	Vector3 middleOfScreen;


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
		// Get the vector the screen center 
		middleOfScreen = new Vector3(Screen.width/2, Screen.height/2, 0f);

		if (Input.GetButtonDown ("Jump") && Grounded()) {
			// rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
			rb.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -0.5f * Physics.gravity.y), ForceMode.VelocityChange);

		}
		if (inputFire && (lastTimeFired + 1 / rateOfFire) < Time.time)
		{
			lastTimeFired = Time.time;
			// Fire();
		}

		// Set the direction where the player should face
		Vector3 direction = Input.mousePosition - middleOfScreen;
		// Flip to the correct orientation
		Vector3 new_direction = new Vector3(direction.x, 0f, direction.y);
		// transform.LookAt(flipped);
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (new_direction), mouseSensitivity * Time.deltaTime);

	}
		
	// Look below the character and see if there is a collider
	bool Grounded () {
		return Physics.Raycast (transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);
	}

	// Pooping
	void Fire () {
		
	}


}
