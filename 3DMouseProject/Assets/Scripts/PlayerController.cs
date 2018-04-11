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


	[Header ("Others")]
	public float speed = 2f;
	private Rigidbody rb;
	public float mouseSensitivity;
	Vector3 middleOfScreen;
	public Vector3 facing;

	public static PlayerController instance;

	// Use this for initialization
	void Start () {
		instance = this;
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
		inputFire = Input.GetMouseButton (0);

		if (Input.GetButtonDown ("Jump") && Grounded()) {
			// rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
			rb.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -0.5f * Physics.gravity.y), ForceMode.VelocityChange);

		}

		// Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		// Debug.Log ("Mouse Position: " + mousePos);
		// Set the direction where the player should face
		Vector3 direction = Input.mousePosition - middleOfScreen;
		// Vector3 direction = Input.mousePosition;
		// Vector3 direction = mousePos - middleOfScreen;
		// Vector3 direction = Input.mousePosition - transform.position;

		// Vector3 direction = Input.mousePosition - transform.position;
		// Flip to the correct orientation
		facing = new Vector3(direction.x, 0f, direction.y);
		Debug.Log ("Facing: " + facing);
		// transform.LookAt(facing);
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (facing), mouseSensitivity * Time.deltaTime);

	}
		
	/// <summary>
	/// Helper function to check whether the player is grounded
	/// </summary>
	bool Grounded () {
		return Physics.Raycast (transform.position, Vector3.down, coll.bounds.extents.y + 0.1f);
	}

}
