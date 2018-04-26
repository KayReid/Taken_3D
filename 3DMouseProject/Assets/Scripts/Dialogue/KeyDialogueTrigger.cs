using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDialogueTrigger : MonoBehaviour {


	public Dialogue dialogue;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {
			TriggerKeyDialogue ();
		}
	}
		
	public void TriggerKeyDialogue() {

		if (!Key.keyActivated) {
			FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
		} 

	}


}
