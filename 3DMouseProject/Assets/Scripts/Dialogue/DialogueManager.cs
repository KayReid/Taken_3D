using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour {

	public Text dialogueText;
	private Queue<string> sentences;

	public Animator anim;

	private PlayerController pc;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		pc = FindObjectOfType<PlayerController> ();
	}

	public void StartDialogue(Dialogue dialogue){
		pc.canMove = false;
		pc.canShoot = false;
		anim.SetBool ("IsOpen", true);

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}
		DisplayNextSentence ();
	}


	public void DisplayNextSentence (){
		if (sentences.Count == 0) {
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines();
		StartCoroutine (TypingSentence (sentence));
	}

	void EndDialogue(){
		anim.SetBool ("IsOpen", false);
		pc.canMove = true;
		pc.canShoot = true;
	}


	IEnumerator TypingSentence (string sentence){
		dialogueText.text = "";

		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}

	}




}
