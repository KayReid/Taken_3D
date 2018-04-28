using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Door that will be opened when all the cannon pieces are collected
public class ExitDoor : MonoBehaviour {


	private DoorStatus status = DoorStatus.Closed;
	public GameObject cannonPrefab;

	public Dialogue dialogue;

	[SerializeField]
	private AudioClip cannonShootingSoundClip;

	private AudioSource audioSource;

	void OnTriggerEnter(Collider other) {

		if (status != DoorStatus.Animating) {
			if (status == DoorStatus.Closed) {
				if (other.CompareTag ("Player")) {
					if (Canon.canonCounter == 5) {
						StartCoroutine(spawnCanon());
					} else {
						FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
					}
				}
			}
		}
	}


	IEnumerator spawnCanon() {
		Debug.Log("Waiting 3 seconds to spawn canon");
		yield return new WaitForSeconds(1f);
		Debug.Log("Canon instantiated");
		Instantiate(cannonPrefab, new Vector3(23.4f, 2.2f, 122.0f), Quaternion.Euler(0, 45, 0));
		StartCoroutine(shootCanon());
	}
		

	IEnumerator shootCanon() {
		Debug.Log("Shooting Cannon in 1 second");
		yield return new WaitForSeconds(1f);
		Debug.Log("Shooting cannon ball");
		if (cannonShootingSoundClip != null) {
			audioSource.PlayOneShot (cannonShootingSoundClip, 0.7F);
		}
		StartCoroutine (destroyExit ());
	}

	IEnumerator destroyExit() {
		yield return new WaitForSeconds(0.2f);
		Debug.Log("Destroy the Exit");
		Destroy (gameObject);
	}

}

