﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Door that will be opened when find a daughter
public class Level1Door : MonoBehaviour {


	private DoorStatus status = DoorStatus.Closed;

	public Dialogue dialogue;


	[SerializeField]
	private Transform halfDoorLeftTransform;	//	Left panel of the sliding door
	[SerializeField]
	public Transform halfDoorRightTransform;	//	Right panel of the sliding door

	[SerializeField]
	private float slideDistance	= 1.3f;		//	Sliding distance to open each panel the door

	private Vector3 leftDoorClosedPosition;
	private Vector3 leftDoorOpenPosition;

	private Vector3 rightDoorClosedPosition;
	private Vector3 rightDoorOpenPosition;

	[SerializeField]
	private float speed = 1f;					//	Speed for opening and closing the door


	//	Sound Fx
	[SerializeField]
	private AudioClip doorOpeningSoundClip;
	[SerializeField]
	public AudioClip doorClosingSoundClip;

	private AudioSource audioSource;

	public NavMeshObstacle doorObstacle;

	// Use this for initialization
	void Start () {
		leftDoorClosedPosition	= new Vector3 (0f, 0f, 0f);
		leftDoorOpenPosition	= new Vector3 (0f, 0f, slideDistance);

		rightDoorClosedPosition	= new Vector3 (0f, 0f, 0f);
		rightDoorOpenPosition	= new Vector3 (0f, 0f, -slideDistance);

		audioSource = GetComponent<AudioSource>();

		doorObstacle = GetComponent<NavMeshObstacle>();
	}

	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider other) {

		if (status != DoorStatus.Animating) {
			if (status == DoorStatus.Closed) {
				if (other.CompareTag ("Player")) {
					if (Level2Door.foundDaughter) {
						StartCoroutine (OpenDoors ());
					} else {
						FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
					}
				}
			}
		}
	}

	void OnTriggerExit(Collider other) {

		if (status != DoorStatus.Animating) {
			if (status == DoorStatus.Open) {
				print ("yo close it");
				if (Level2Door.rescuedDaughter) {
					print ("got it");
					// If rescued the daughter, the door will interact with the daughter mouse 
					if (other.CompareTag ("Daughter")) {
						print ("close");
						StartCoroutine (CloseDoors ());
					}
				} else {
					// If not rescued the daughter, the door will interact with the player mouse 
					if (other.CompareTag ("Player")) {
						StartCoroutine (CloseDoors ());
					}
				}
			}
		}
	}

	IEnumerator OpenDoors () {

		if (doorOpeningSoundClip != null) {
			audioSource.PlayOneShot (doorOpeningSoundClip, 0.7F);
		}

		status = DoorStatus.Animating;

		float t = 0f;

		while (t < 1f) {
			t += Time.deltaTime * speed;

			halfDoorLeftTransform.localPosition = Vector3.Slerp(leftDoorClosedPosition, leftDoorOpenPosition, t);
			halfDoorRightTransform.localPosition = Vector3.Slerp(rightDoorClosedPosition, rightDoorOpenPosition, t);

			yield return null;
		}


		status = DoorStatus.Open;
		doorObstacle.enabled = false;
	}

	IEnumerator CloseDoors () {

		if (doorClosingSoundClip != null) {
			audioSource.PlayOneShot(doorClosingSoundClip, 0.7F);
		}

		status = DoorStatus.Animating;

		float t = 0f;

		while (t < 1f) {
			t += Time.deltaTime * speed;

			halfDoorLeftTransform.localPosition = Vector3.Slerp(leftDoorOpenPosition, leftDoorClosedPosition, t);
			halfDoorRightTransform.localPosition = Vector3.Slerp(rightDoorOpenPosition, rightDoorClosedPosition, t);

			yield return null;
		}

		status = DoorStatus.Closed;
		doorObstacle.enabled = true;

	}

}
	
