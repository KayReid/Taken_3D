using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Module for player controller input when using a PlatformController. Uses standart Horizontal and Vertical input axis.
/// Also handles shooting.
/// </summary>
[RequireComponent(typeof(PlayerController))]
public class PlayerInputeModules : MonoBehaviour {

	PlayerController controller;

	private bool inputJump = false;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
	}

	void Update () {

		if (Input.GetButtonDown ("Jump")) {
			inputJump = true;
		}

	}

	// Update is called once per frame
	void FixedUpdate () {
				
		controller.inputJump = inputJump;
		controller.moveLR = Input.GetAxisRaw ("Horizontal");
		controller.moveFB = Input.GetAxisRaw ("Vertical");
		controller.inputFire = Input.GetMouseButtonDown(0);
		inputJump = false;

	}
}
