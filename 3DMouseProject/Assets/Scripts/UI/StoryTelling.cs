using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryTelling : MonoBehaviour {

	[TextArea (4, 30)]
	public string[] page;
	int PageNumber = -1;
	Text view;
	public string levelToLoad;

	// Use this for initialization
	void Start () {
		view = GetComponent<Text> ();
		PageNumber = -1;
		PageTurn ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			PageTurn ();
		}
	}

	void PageTurn() {
		PageNumber++;
		if (PageNumber < page.Length) {
			StartCoroutine (TypingSentence (page [PageNumber]));
		} else {
			SceneManager.LoadScene(levelToLoad);
		}
	}

	IEnumerator TypingSentence (string sentence){
		view.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			view.text += letter;
			yield return null;
		}

	}


}
