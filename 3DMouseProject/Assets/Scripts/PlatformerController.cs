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
