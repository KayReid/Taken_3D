using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CannonDoor : MonoBehaviour {


	private DoorStatus status = DoorStatus.Closed;
	public GameObject canonDoorPrefab;


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


	// Use this for initialization
	void Start () {
		leftDoorClosedPosition	= new Vector3 (0f, 0f, 0f);
		leftDoorOpenPosition	= new Vector3 (0f, 0f, slideDistance);

		rightDoorClosedPosition	= new Vector3 (0f, 0f, 0f);
		rightDoorOpenPosition	= new Vector3 (0f, 0f, -slideDistance);

		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {


	}

	
	void OnTriggerEnter(Collider other) {

		if (status != DoorStatus.Animating) {
			if (status == DoorStatus.Closed) {
				if (other.CompareTag ("Player")) {
					if (Canon.canonCounter == 5) {
						StartCoroutine (OpenDoors ());
					} else {
						FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
					}
				}
			}
		}
	}
	


	/* Edit this later with 5 canon parts
	void OnTriggerEnter(Collider other) {
		
		if (other.CompareTag ("Player")) {
			Debug.Log("Door: Player Collided");
			StartCoroutine(spawnCanon(3f));
		}

	}
	*/



	void OnTriggerExit(Collider other) {

		if (status != DoorStatus.Animating) {
			if (status == DoorStatus.Open) {
				if (other.CompareTag ("Player")) {
					StartCoroutine (CloseDoors ());
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
		StartCoroutine(spawnCanon(2f));
		// TODO: Plays Animation and then destroy canon prefab
		// Player exits

	}

	/*	Transform of a canon for the main door:
  		Position: 3.5 4.0 67.5
  		Rotation: 0 45 0
 	*/
	IEnumerator spawnCanon(float seconds) {
		Debug.Log("Waiting 3 seconds to spawn canon");
		yield return new WaitForSeconds(seconds);
		Debug.Log("Canon instantiated");
		Instantiate(canonDoorPrefab, new Vector3(3.5f, 4.0f, 67.5f), Quaternion.Euler(0, 45, 0));
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

	}



}

