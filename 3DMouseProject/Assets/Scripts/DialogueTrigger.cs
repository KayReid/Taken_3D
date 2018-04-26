using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ATTACH THIS SCRIPT TO THE DOORS THAT ARE CLOED FOR CERTAIN REASONS
public class DialogueTrigger : MonoBehaviour {


	public Dialogue dialogue;


	// public string requirement;

	// private float distance;
	// public GameObject messenger = GameObject.FindGameObjectWithTag("Messenger");

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {
			TriggerDialogue ();
		}
	}




	// This function will be called when the player is trying to open the door without collecting 
	// all the cannon parts and the key

	public void TriggerDialogue() {

		if (!Key.keyActivated) {
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
		} 

	}



}
