using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDialogueTrigger : MonoBehaviour {


	public Dialogue dialogue;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) {
			TriggerCannonDialogue ();
		}
	}
		
	public void TriggerCannonDialogue() {

		//if (Canon.canonCounter != 5) {
		//	FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
		//}

	}


}
