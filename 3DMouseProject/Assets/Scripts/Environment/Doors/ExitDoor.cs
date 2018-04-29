using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Door that will be opened when all the cannon pieces are collected
public class ExitDoor : MonoBehaviour {


	private DoorStatus status = DoorStatus.Closed;
	public GameObject cannonPrefab;

	public Dialogue preDialogue;
	public Dialogue postDialogue;

	[SerializeField]
	private AudioClip cannonShootingSoundClip;


	void OnTriggerEnter(Collider other) {
		if (status != DoorStatus.Animating) {
			if (status == DoorStatus.Closed) {
				if (other.CompareTag ("Player")) {
					if (Cannon.cannonCounter == 5) {
						FindObjectOfType<DialogueManager> ().StartDialogue (postDialogue);
						StartCoroutine(spawnCanon());
					} else {
						FindObjectOfType<DialogueManager> ().StartDialogue (preDialogue);
					}
				}
			}
		}
	}


	IEnumerator spawnCanon () {
		yield return new WaitForSeconds(1f);
		Instantiate(cannonPrefab, new Vector3(22.2f, 1.9f, 107.4f), Quaternion.Euler(0, 45, 0));
		StartCoroutine(shootCanon());
	}
		

	IEnumerator shootCanon () {
		yield return new WaitForSeconds(3f);
		if (cannonShootingSoundClip != null) {
			AudioSource.PlayClipAtPoint(cannonShootingSoundClip, transform.position); // play sound clip
		}
		StartCoroutine(destroyExit ());
	}

	IEnumerator destroyExit () {
		yield return new WaitForSeconds(1f);
		Destroy (gameObject);
		SceneManager.LoadScene ("Ending");
	}

}

