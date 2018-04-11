using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script for general purpose 3D controls for any object that can move when grounded.
/// </summary>
/// 
/// 
/// 
/// 
/// 
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
/// 
/// 
/// 
/// 
/// 
/// 
/// 
/// 


[RequireComponent (typeof(Rigidbody))]
public class PlatformerController : MonoBehaviour {

	[Header ("Controls")]
	[HideInInspector] public float moveLR; // move left and right
	[HideInInspector] public float moveFB; // move back and forth
	// [HideInInspector] public Vector2 input;	// horizontal and vertical movement (W,S,A,D)
	[HideInInspector] public bool inputFire;    // Shoot (whether Mouse is pressed or not)


	[Header ("Shooting")]



	[Header ("Others")]
	private float speed;
	private Rigidbody rb;
	// private float gravity = 5f;
	public Quaternion targetRotation;


	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		
		// Vector3 velocity = rb.velocity;



		//velocity.x = moveLR * speed; // move left and right
		// velocity.z = moveFB * speed; // move back and forth

		// velocity.x = transform.right * moveLR * speed;
		// velocity.z = transform.forward * moveFB * speed;
		rb.velocity = transform.forward * moveFB * speed;

		//float angle = Mathf.Atan2(velocity.z, velocity.x) * Mathf.Rad2Deg - 90; // multiply Mathf.Rad2Deg to convert radian to degree
		//transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward); // the axis we need is global z-axis, which 

		targetRotation = Quaternion.AngleAxis (speed * moveLR * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;


		// velocity.y += -gravity * Time.deltaTime;
		// rb.velocity = velocity;
	}
}




// Debug.Log ("Mouse Position: " + mousePos);
// Set the direction where the player should face
// Vector3 direction = Input.mousePosition - middleOfScreen;
// Vector3 direction = Input.mousePosition;
//direction.x = mousePos.x - middleOfScreen.x;
//direction.y = 0f;
//direction.z = mousePos.z - middleOfScreen.y;
// Vector3 direction = Input.mousePosition - transform.position;
// Debug.Log ("Mouse Position: " + Input.mousePosition);
/*
		Vector3 target = Input.mousePosition;
		Debug.Log ("target: " + target);
		// Vector3 newtarget = new Vector3 (target.x, 0f, target.y);
		Vector3 origin = Camera.main.WorldToScreenPoint (transform.position);
		Debug.Log ("origin: " + origin);
		direction = target - origin;
		Vector3 facing = new Vector3(direction.x, 0f, direction.y);
		Debug.Log ("facing: " + facing);
		*/
// float angle = Mathf.Atan2(facing.x, facing.z) * Mathf.Rad2Deg; // multiply Mathf.Rad2Deg to convert radian to degree
// transform.rotation = Quaternion.AngleAxis (angle, Vector3.up); 

/*
// Working:
Vector3 direction = Input.mousePosition - middleOfScreen;
Vector3 facing = new Vector3(direction.x, 0f, direction.y);
transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (facing), mouseSensitivity * Time.deltaTime);
*/


// Flip to the correct orientation
// facing = new Vector3(direction.x, 0f, direction.y);
// Debug.Log ("Facing: " + facing);
// transform.LookAt(facing);
//transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (facing), mouseSensitivity * Time.deltaTime);

