using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Door that will be opened when all the cannon pieces are collected
public class ExitDoor : MonoBehaviour {


	private DoorStatus status = DoorStatus.Closed;
	public GameObject canonDoorPrefab;


	public Dialogue dialogue;

	[SerializeField]
	private Transform halfDoorLeftTransform;	//	Left panel of the sliding door
	[SerializeField]
	public Transform halfDoorRightTransform;	//	Right panel of the sliding door

	[SerializeField]
	private float slideDistance	= 1.3f;		//	Sliding distance to open each panel the door


	void OnTriggerEnter(Collider other) {

		if (status != DoorStatus.Animating) {
			if (status == DoorStatus.Closed) {
				if (other.CompareTag ("Player")) {
					if (Canon.canonCounter == 5) {
						StartCoroutine(spawnCanon(1f));
					} else {
						FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
					}
				}
			}
		}
	}


	IEnumerator spawnCanon(float seconds) {
		Debug.Log("Waiting 3 seconds to spawn canon");
		yield return new WaitForSeconds(seconds);
		Debug.Log("Canon instantiated");
		Instantiate(canonDoorPrefab, new Vector3(23.4f, 2.2f, 122.0f), Quaternion.Euler(0, 45, 0));
	}
		

}

