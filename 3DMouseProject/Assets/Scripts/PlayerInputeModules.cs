using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Module for player controller input when using a PlatformController. Uses standart Horizontal and Vertical input axis.
/// Also handles shooting.
/// </summary>
// [RequireComponent(typeof(PlatformerController))]
//
//
//
//
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
// DON'T USE THIS CODE
//
//
//
//


public class PlayerInputeModules : MonoBehaviour {

	PlatformerController controller;
	float moveFB; // move back and forth
	float moveLR; // move left and right


	// Use this for initialization
	void Start () {
		controller = GetComponent<PlatformerController>();
	}

	void Update (){
		
		controller.inputFire = Input.GetMouseButtonDown(0);


	}

	// Update is called once per frame
	void FixedUpdate () {

		controller.moveLR = Input.GetAxisRaw ("Horizontal");
		controller.moveFB = Input.GetAxisRaw ("Vertical");

	}
}
