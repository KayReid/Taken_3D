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

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		controller.moveLR = Input.GetAxisRaw ("Horizontal");
		controller.moveFB = Input.GetAxisRaw ("Vertical");
		controller.inputFire = Input.GetMouseButtonDown(0);
	}
}
