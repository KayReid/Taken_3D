using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Door that will be opened when find a key
public class Level2Door : MonoBehaviour {

	// public static Level2Door instance; 
	private DoorStatus status = DoorStatus.Closed;

	public static bool rescuedDaughter;
	public static bool foundDaughter;
	public Dialogue preDialogue;
	public Dialogue postDialogue;

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

	public NavMeshObstacle doorObstacle;

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

		rescuedDaughter = false;
		foundDaughter = false;

		doorObstacle = GetComponent<NavMeshObstacle>();
	}
		
	void OnTriggerEnter(Collider other) {

		if (status != DoorStatus.Animating) {
			if (status == DoorStatus.Closed) {
				if (other.CompareTag ("Player")) {
					if (Key.keyActivated) {
						StartCoroutine (OpenDoors ());
						FindObjectOfType<DialogueManager> ().StartDialogue (postDialogue);
						rescuedDaughter = true;
						doorObstacle.enabled = false;

					} else {
						FindObjectOfType<DialogueManager> ().StartDialogue (preDialogue);
						foundDaughter = true;
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

	}
		

}

